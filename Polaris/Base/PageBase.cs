using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interactions;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using PointerInputDevice = OpenQA.Selenium.Interactions.PointerInputDevice;


namespace Polaris.Base
{
    /// <summary>
    ///     Shared PageBase for all Xamarin test targets.
    ///     Test target specific app functions are implemented in the individual projects.
    /// </summary>
    public abstract class PageBase : AppBase
    {
        private ITouchAction touchAction;

        public static AppiumDriver<IWebElement>? driver
        {
            get => AppInitializer.AppiumDriver;
            set => AppInitializer.AppiumDriver = value;
        }
        
        /// <summary>
        /// Retrieves the automation ID for a given element name.
        /// </summary>
        /// <param name="elementName">The name of the element for which to retrieve the automation ID.</param>
        /// <returns>The automation ID as a string, or an empty string if an ID is not defined.</returns>
        public virtual string GetAutomationID(string elementName)
        {
            // You can overwrite this method in a derived page class.
            return string.Empty;
        }
        
        /// <summary>
        /// This method moves the slider to the specified percentage
        /// </summary>
        /// <param name="sliderElement">The webelement for which to move the slider</param>
        /// <param name="percentage">The specified percentage by which the sldier element need to be moved</param>
        /// <param name="LocatorStrategy">The slider element can be identified by different  locators</param>
        public void MoveSliderToPercentage(string sliderElement, int percentage, LocatorStrategy locatorStrategy)
        {
            try
            {
                if (driver != null)
                {
                    IWebElement slider;

                    // Find the slider element based on the provided locator strategy
                    switch (locatorStrategy)
                    {
                        case LocatorStrategy.Id:
                            slider = driver.FindElement(By.Id(sliderElement));
                            break;
                        case LocatorStrategy.IosClassChain:
                            slider = driver.FindElement(MobileBy.IosClassChain(sliderElement));
                            break;
                        case LocatorStrategy.XPath:
                            slider = driver.FindElement(By.XPath(sliderElement));
                            break;
                        default:
                            throw new ArgumentException("Invalid locator strategy");
                    }

                    // Calculate the value to send based on the percentage
                    double valueToSend = percentage / 100.0;
                    string valueAsString = valueToSend.ToString("0.00"); // Ensures the string has two decimal places

                    // Clear the current value and send the new value
                    slider.Clear();
                    slider.SendKeys(valueAsString);
                        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error moving slider: {e.Message}");
                throw; // Re-throw the exception to handle it further up the call stack if necessary
            }
                
        }
        
        /// <summary>
        /// This method resets the slider to zero percentage
        /// </summary>
        /// <param name="sliderElement">The webelement for which to move the slider</param>
        /// <param name="LocatorStrategy">The slider element can be identified by different  locators</param>
        public void ResetSliderToZero(string sliderElement, LocatorStrategy locatorStrategy)
        {
            try
            {
                if (driver != null)
                {
                    IWebElement slider;

                    // Find the slider element based on the provided locator strategy
                    switch (locatorStrategy)
                    {
                        case LocatorStrategy.Id:
                            slider = driver.FindElement(By.Id(sliderElement));
                            break;
                        case LocatorStrategy.IosClassChain:
                            slider = driver.FindElement(MobileBy.IosClassChain(sliderElement));
                            break;
                        case LocatorStrategy.XPath:
                            slider = driver.FindElement(By.XPath(sliderElement));
                            break;
                        default:
                            throw new ArgumentException("Invalid locator strategy");
                    } 

                    // Get the current value of the slider
                    string currentValue = slider.GetAttribute("value");

                    // If the current value is not "0 %", move the slider to "0 %"
                    if (currentValue != "0 %")
                    {
                        MoveSliderToPercentage(sliderElement, 0, LocatorStrategy.XPath);
                    } 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error moving slider: {e.Message}");
                throw; // Re-throw the exception to handle it further up the call stack if necessary
            }
        }   

        /// <summary>
        /// This method returns an IWebElement and takes a string parameter called elementName. 
        /// It is used to find and return a web element based on the specified elementName.
        /// </summary>
        /// <param name="elementName">The name of the element to find.</param>
        /// <returns>An IWebElement representing the found web element, or null if no element is found.</returns>
        public virtual IWebElement FindElement(string elementName)
        {
            // Default implementation: return null, indicating no element was found.
            return null;
        }

        #region Generic page functions

        /// <summary>
        ///     Appium IsDisplayed Method to check whether the element is displayed
        /// </summary>
        public bool IsElementDisplayed(IWebElement element)
        {
            WaitForElementUsingExplicitWait(element, TimeSpan.FromSeconds(60));
            try
            {
                element.Displayed.Equals(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsElementDisplayedForAppium(PageBase page, string element)
        {
            try
            {
                WaitForElementToBeVisible(page, element, 2);
                return page.FindElement(element).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsElementNotDisplayed(IWebElement element)
        {
            WaitForElementUsingImplicitWait(5);
            try
            {
                element.Displayed.Equals(false);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>
        ///     Appium TapByCoordinates method to click on element using coordinates
        /// </summary>
        public void TapBycoordinates(int x, int y)
        {
            var touchAction = new TouchAction(AppInitializer.AppiumDriver);
            touchAction.Tap(x, y).Perform();
        }

        /// <summary>
        ///     Appium IsSelected Method to check whether the element is selected
        /// </summary>
        public bool IsElementSelected(IWebElement element)
        {
            try
            {
                element.Selected.Equals(true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void WaitForElementUsingImplicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        /// <summary>
        /// Waits until the specified element is visible on the page.
        /// </summary>
        /// <param name="page">The page on which to find the element.</param>
        /// <param name="elementName">The name of the element to check for visibility.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait before timing out.</param>
        public void WaitForElementToBeVisible(PageBase page, string elementName, int timeoutInSeconds)
        {
            var automationID = page.GetAutomationID(elementName);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                wait.Until(driver =>
                {
                    try
                    {
                        return page.FindElement(elementName).Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new ElementVisibilityException($"Element '{elementName}' not found using AutomationID: '{automationID}' after waiting for {timeoutInSeconds} seconds.");
            }
        }

        /// <summary>
        /// Waits until the specified element is no longer visible on the page.
        /// </summary>
        /// <param name="page">The page on which to find the element.</param>
        /// <param name="elementName">The name of the element to check for invisibility.</param>
        /// <param name="timeoutInSeconds">The number of seconds to wait before timing out.</param>
        public void WaitForElementToBeNotVisible(PageBase page, string elementName, int timeoutInSeconds)
        {
            var automationID = page.GetAutomationID(elementName);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                wait.Until(driver =>
                {
                    try
                    {
                        return !page.FindElement(elementName).Displayed;
                    }
                    catch (NoSuchElementException ex)
                    {
                        return true;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                if (elementName.Contains("ConsentPart1Body1") && SettingsBase.DeviceName.Contains("Pixel 8 Pro"))
                {
                    Console.WriteLine($"Warrning: Element '{elementName}' with AutomationID: {automationID} was still visible after waiting for {timeoutInSeconds} seconds. And this is exception for Pixel 8 Pro");
                    return;
                }

                throw new ElementVisibilityException($"Element '{elementName}' with AutomationID: {automationID} was still visible after waiting for {timeoutInSeconds} seconds.");
            }
        }

        public void WaitForElementFluentWait(IWebElement appiumWebElement)
        {
            var fluentWait = new DefaultWait<AppiumDriver<IWebElement>>(AppInitializer.AppiumDriver)
            {
                Timeout = TimeSpan.FromMilliseconds(30000),
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            fluentWait.Until(driver =>
            {
                try
                {
                    return appiumWebElement.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }


        public void WaitForExplicitWait(IWebElement element)
        {
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(50000)).Until(d => element.Displayed);
        }

        public void SetImplicitWait(TimeSpan timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = timeout;
        }

        public void WaitForElementUsingExplicitWait(IWebElement element, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            try
            {
                wait.Until(driver => element.Displayed && element.Enabled);
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout waiting for element to be clickable.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found in the DOM.");
            }
        }

        public void WaitForExplicitWait(IWebElement element, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout waiting for element to be clickable.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element not found in the DOM.");
            }
        }

        /// <summary>
        ///     Appium Click Method to click on element
        /// </summary>
        public void ClickOnElement(IWebElement element)
        {
            try
            {
                WaitForElementFluentWait(element);
                WaitForElementUsingExplicitWait(element, TimeSpan.FromMilliseconds(10000));
                element.Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to click on the element: {element}. {e.Message}");
            }
        }

        public void SendKeysToElement(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to send keys to the element: {element}. {e.Message}");
            }
        }

        public enum SwipeDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public void Swipe(IWebElement sourceElement, IWebElement targetElement, SwipeDirection direction,
            int duration = 800)
        {
            WaitForElementUsingExplicitWait(sourceElement, TimeSpan.FromMilliseconds(15000));
            var startX = sourceElement.Location.X + sourceElement.Size.Width / 2;
            var startY = sourceElement.Location.Y + sourceElement.Size.Height / 2;
            var endX = targetElement.Location.X + targetElement.Size.Width / 2;
            var endY = targetElement.Location.Y + targetElement.Size.Height / 2;
            var swipeDuration = duration / 2;
            switch (direction)
            {
                case SwipeDirection.Left:
                    touchAction = new TouchAction(driver);
                    touchAction.Press(startX, startY).Wait(swipeDuration)
                        .MoveTo(endX, endY).Release().Perform();
                    break;
                case SwipeDirection.Right:
                    touchAction.Press(endX, endY).Wait(swipeDuration)
                        .MoveTo(startX, startY).Release().Perform();
                    break;
                default:
                    throw new NotSupportedException("Invalid swipe direction.");
            }
        }

        public void Swipe(IWebElement sourceElement, double swipePercentage, SwipeDirection direction,
            int duration = 800)
        {
            WaitForElementUsingExplicitWait(sourceElement, TimeSpan.FromMilliseconds(15000));
            var startX = sourceElement.Location.X + sourceElement.Size.Width / 2;
            var startY = sourceElement.Location.Y + sourceElement.Size.Height / 2;
            var screenWidth = driver.Manage().Window.Size.Width;
            var swipeDistance = (int)(screenWidth * swipePercentage);
            int endX, endY;
            switch (direction)
            {
                case SwipeDirection.Left:
                    endX = startX - swipeDistance;
                    endY = startY;
                    break;
                case SwipeDirection.Right:
                    endX = startX + swipeDistance;
                    endY = startY;
                    break;
                default:
                    throw new NotSupportedException("Invalid swipe direction.");
            }

            var swipeDuration = duration / 2;
            var touchActions = new TouchAction(driver);
            touchAction.Press(startX, startY).Wait(swipeDuration).MoveTo(endX, endY).Release().Perform();
        }

        /// <summary>
        /// Initiates a scroll action in the specified direction with a given distance.
        /// </summary>
        /// <param name="swipeDirection">Specifies the direction of the scroll action.</param>
        /// <param name="distance">A ratio of the screen height; `1.0` means a full-screen-worth of scrolling. This is an optional parameter.</param>
        /// <param name="elementId">The ID of the element to scroll on, if applicable. This is an optional parameter.</param>
        public void Scroll(SwipeDirection swipeDirection, double? distance = null, string elementId = null)
        {
            // Determine the direction for the scroll gesture based on the swipeDirection parameter
            string direction = string.Empty;

            // Determine the specified direction
            switch (swipeDirection)
            {
                case SwipeDirection.Up:
                    direction = "up"; // Scrolls the content upwards
                    break;
                case SwipeDirection.Down:
                    direction = "down"; // Scrolls the content downwards
                    break;
                case SwipeDirection.Left:
                    direction = "left"; // Scrolls the content to the left
                    break;
                case SwipeDirection.Right:
                    direction = "right"; // Scrolls the content to the right
                    break;
            }

            // Create the scroll object with the specified direction and any optional parameters
            Dictionary<string, object> scrollObject = new Dictionary<string, object>
            {
                { "direction", direction }
            };

            // If a distance ratio is provided, add it to the scroll object
            if (distance.HasValue)
            {
                scrollObject.Add("distance", distance.Value);
            }

            // If an element ID is provided, add it to the scroll object to specify the element to scroll
            if (!string.IsNullOrEmpty(elementId))
            {
                scrollObject.Add("elementId", elementId);
            }

            // Execute the scroll action using the mobile command
            ((IJavaScriptExecutor)driver).ExecuteScript("mobile: scroll", scrollObject);
        }
        
        //This function is useful in case that the cross platform scroll function (SwipeByCooridnates) is not working for iOS device
        public void ScrollIOS(SwipeDirection swipeDirection, IWebElement element)
        {
            var scrollAttempts = 3;
            var args = new Dictionary<string, object>
            {
                { "direction", swipeDirection.ToString().ToLower() }
            };
            try
            {
                for (var i = 0; i < scrollAttempts; i++)
                    if (!IsElementAppears(element))
                        driver.ExecuteScript("mobile: scroll", args);
            }

            catch (Exception e)
            {
                throw new Exception($"iOS scroll {swipeDirection} to element failed: {e.Message}");
            }
        }

        /// <summary>
        /// Scrolls in the specified direction using touch actions until the specified element appears on the screen.
        /// </summary>
        /// <param name="swipeDirection">The direction to swipe (Up or Down).</param>
        /// <param name="element">The name of the element to scroll into view.</param>
        /// <param name="page">The page object containing the element to scroll into view.</param>
        /// <exception cref="ElementVisibilityException">Thrown when the element is not found on the page after the maximum number of scroll attempts.</exception>
        /// <exception cref="Exception">Thrown when the swipe action fails due to an unexpected error.</exception>
        /// <remarks>
        /// This method uses touch actions to simulate a swipe gesture on the screen. It continues to swipe in the specified direction
        /// until the element becomes visible or the maximum number of scroll attempts is reached. The swipe gesture is performed by
        /// creating a sequence of pointer actions that move from the start coordinates to the end coordinates, simulating a touch and drag motion.
        /// </remarks>
        public void ScrollToElement(SwipeDirection swipeDirection, string element, PageBase page)
        {
            const int MaxScrollAttempts = 20;
            const double ScrollHeightRatio = 0.25;
            int scrollAttempts = 0;
            bool elementDisplayed = false;

            var windowSize = driver.Manage().Window.Size;
            int startX = windowSize.Width / 2;
            int endX = startX;
            int startY = windowSize.Height / 2;
            int endY = (int)(windowSize.Height * ScrollHeightRatio);

            do
            {
                try
                {
                    elementDisplayed = IsElementDisplayedForAppium(page, element);
                }
                catch (Exception)
                {
                    // Continue to scroll if the element is not displayed
                    elementDisplayed = false;
                }

                if (!elementDisplayed)
                {
                    var pointerInputDevice = new PointerInputDevice(PointerKind.Touch, "finger");
                    var actionSequence = new ActionSequence(pointerInputDevice, 0);

                    switch (swipeDirection)
                    {
                        case SwipeDirection.Down:
                            AddSwipeActions(actionSequence, pointerInputDevice, startX, startY, endX, endY);
                            break;
                        case SwipeDirection.Up:
                            AddSwipeActions(actionSequence, pointerInputDevice, startX, endY, endX, startY);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(swipeDirection), swipeDirection, null);
                    }

                    driver.PerformActions(new List<ActionSequence> { actionSequence });

                    if (++scrollAttempts > MaxScrollAttempts)
                    {
                        throw new ElementVisibilityException($"{element} using: {page.GetAutomationID(element)} was not found on the page after {MaxScrollAttempts} scroll attempts.");
                    }
                }
            } while (!elementDisplayed && scrollAttempts <= MaxScrollAttempts);
        }

        /// <summary>
        /// Scrolls in the specified direction using touch actions until the specified element appears on the screen.
        /// </summary>
        /// <param name="swipeDirection">The direction to swipe (Up or Down).</param>
        /// <param name="element">The web element to scroll into view.</param>
        /// <exception cref="ElementVisibilityException">Thrown when the element is not found on the page after the maximum number of scroll attempts.</exception>
        /// <exception cref="Exception">Thrown when the swipe action fails due to an unexpected error.</exception>
        /// <remarks>
        /// This method uses touch actions to simulate a swipe gesture on the screen. It continues to swipe in the specified directionž
        /// until the element becomes visible or the maximum number of scroll attempts is reached. The swipe gesture is performed by
        /// creating a sequence of pointer actions that move from the start coordinates to the end coordinates, simulating a touch and drag motion.
        /// </remarks>
        public void ScrollUsingPointer(SwipeDirection swipeDirection, IWebElement element)
        {
            const int MaxScrollAttempts = 10;
            const double ScrollHeightRatio = 0.25;
            int scrollAttempts = 0;

            try
            {
                var windowSize = driver.Manage().Window.Size;
                int startX = windowSize.Width / 2;
                int endX = startX;
                int startY = windowSize.Height / 2;
                int endY = (int)(windowSize.Height * ScrollHeightRatio);

                while (!IsElementAppears(element))
                {
                    var pointerInputDevice = new PointerInputDevice(PointerKind.Touch, "finger");
                    var actionSequence = new ActionSequence(pointerInputDevice, 0);

                    switch (swipeDirection)
                    {
                        case SwipeDirection.Down:
                            AddSwipeActions(actionSequence, pointerInputDevice, startX, startY, endX, endY);
                            break;
                        case SwipeDirection.Up:
                            AddSwipeActions(actionSequence, pointerInputDevice, startX, endY, endX, startY);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(swipeDirection), swipeDirection, null);
                    }

                    driver.PerformActions(new List<ActionSequence> { actionSequence });

                    if (++scrollAttempts > MaxScrollAttempts)
                    {
                        throw new ElementVisibilityException("Element was not found on the page after maximum scroll attempts.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Swipe by coordinates failed: {e.Message}", e);
            }
        }

        public void ScrollUsingPointer()
        {
            int scrollAttempts = 0;
            try
            {
                int startX = driver.Manage().Window.Size.Width/2;
                int endX = driver.Manage().Window.Size.Width/2;
                int startY = driver.Manage().Window.Size.Height/2;
                int endY = (int)(driver.Manage().Window.Size.Height*0.25);

                PointerInputDevice pointerInputDevice =
                    new PointerInputDevice(PointerKind.Touch, "finger");
                var actionSequence = new ActionSequence(pointerInputDevice, 0);
                actionSequence.AddAction(pointerInputDevice.CreatePointerMove(0,startX,startY,TimeSpan.FromSeconds(1)));
                actionSequence.AddAction(pointerInputDevice.CreatePointerDown((MouseButton)PointerButton.MiddleMouse));
                actionSequence.AddAction(pointerInputDevice.CreatePointerMove(0,endX,endY,TimeSpan.FromSeconds(1)));
                actionSequence.AddAction(pointerInputDevice.CreatePointerUp((MouseButton)PointerButton.MiddleMouse));
                var actions_seq = new List<ActionSequence>
                {
                    actionSequence
                };
                driver.PerformActions(actions_seq);
            }
            catch (Exception e)
            {
                throw new Exception($"Swipe by coordinated failed: {e.Message}");
            }
        }

        public void ScrollUsingPointerWithHiddenElements(SwipeDirection swipeDirection, IWebElement element)
        {
            var scrollAttempts = 8;
            var windowWidth = driver.Manage().Window.Size.Width;
            var windowHeight = driver.Manage().Window.Size.Height;
            int startX, endX, startY, endY;
            startX = startY = endX = endY = 0;
            Actions actions = new Actions(driver);
            //Checking which direction is given
            switch (swipeDirection)
            {
                case SwipeDirection.Up:
                    startX = endX = windowWidth / 2;
                    startY = (int)(windowHeight * 0.6);
                    endY = (int)(windowHeight * 0.8);
                    break;
                case SwipeDirection.Down:
                    startX = endX = windowWidth / 2;
                    startY = (int)(windowHeight * 0.8);
                    endY = (int)(windowHeight * 0.6);
                    //endY = (int)(element.Location.Y);
                    break;
            }
            try
            {
                for (var i = 0; i < scrollAttempts; i++)
                    if (!IsElementAppears(element))
                    {
                        // Find elements that are not visible to scroll 
                        var allElements = driver.FindElements(By.XPath("//*[@visible='false']")); // Provide the accessibility id of the parent container if needed
                        actions.MoveToElement(allElements.First()).ClickAndHold().MoveByOffset(endX , endY-startY).Release().Perform();
                    }
                    else
                        break;
            }
            catch (Exception e)
            {
                throw new Exception($"Swipe by coordinated failed: {e.Message}");
            }
        }
        
        public void SwipeByCoordinates(SwipeDirection swipeDirection, IWebElement element)
        {
            var scrollAttempts = 8;
            var windowWidth = driver.Manage().Window.Size.Width;
            var windowHeight = driver.Manage().Window.Size.Height;
            int startX, endX, startY, endY;
            startX = startY = endX = endY = 0;

            //Checking which direction is given
            switch (swipeDirection)
            {
                case SwipeDirection.Up:
                    startX = endX = windowWidth / 2;
                    startY = (int)(windowHeight * 0.6);
                    endY = (int)(windowHeight * 0.8);
                    break;
                case SwipeDirection.Down:
                    startX = endX = windowWidth / 2;
                    startY = (int)(windowHeight * 0.8);
                    endY = (int)(windowHeight * 0.6);
                    break;
                case SwipeDirection.Left:
                    startY = endY = windowHeight / 2;
                    startX = (int)(windowHeight * 0.8);
                    endX = (int)(windowHeight * 0.2);
                    break;
                case SwipeDirection.Right:
                    startY = endY = windowHeight / 2;
                    startX = (int)(windowHeight * 0.2);
                    endX = (int)(windowHeight * 0.8);
                    break;
            }

            try
            {
                for (var i = 0; i < scrollAttempts; i++)
                    if (!IsElementAppears(element))
                        new TouchAction(driver)
                            .Press(startX, startY)
                            .Wait(300)
                            .MoveTo(endX, endY)
                            .Release()
                            .Perform();
            }

            catch (Exception e)
            {
                throw new Exception($"Swipe by coordinated failed: {e.Message}");
            }
        }

        public bool IsElementAppears(IWebElement element)
        {
            try
            {
                if (element.GetAttribute("visible") == "true")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNotEndOfPage(string previousPageSource)
        {
            return !previousPageSource.Equals(driver.PageSource);
        }
        public void SwitchToNativeContext()
        {
            try
            {
                driver.Context = "NATIVE_APP";
            }
            catch (Exception e)
            {
                throw new Exception($"Switching to native view failed: {e.Message}");
            }
        }

        public void SwitchToWebViewContext(string requiredContext)
        {
            try
            {
                foreach (var context in driver.Contexts)
                    if (context.Contains(requiredContext))
                        driver.Context = context;
            }
            catch (Exception e)
            {
                throw new Exception($"Switching to web view failed: {e.Message}");
            }
        }


        public void Drag(int fromX, int fromY, int toX, int toY)
        {
            var action = new TouchAction(AppInitializer.AppiumDriver);
            action.Press(fromX, fromY).Wait(1000).MoveTo(toX, toY).Release().Perform();
        }
        
        public enum LocatorStrategy
        {
            Id,
            IosClassChain,
            XPath
        }

       

        public bool Status_favorites(IWebElement element)
        {
            var _result = 0;

            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                _result = int.Parse(element.GetAttribute("value"));
            else
                _result = int.Parse(element.GetAttribute("value"));
            return _result.Equals(1) ? true : false;
        }

        public bool Status_Guide(IWebElement element)
        {
            var _result = 0;

            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                _result = int.Parse(element.GetAttribute("value"));
            else
                _result = int.Parse(element.GetAttribute("value"));
            return _result.Equals(1) ? true : false;
        }

        public bool Status_GuideForAndroid(IWebElement element)
        {
            var _result = "";

            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                _result = element.GetAttribute("text");
            else
                _result = element.GetAttribute("text");
            return _result.Equals("on", StringComparison.OrdinalIgnoreCase) ||
                   _result.Equals("off", StringComparison.OrdinalIgnoreCase);
        }

        public bool Status_favoritesForAndroid(IWebElement element)
        {
            var _result = "";

            if (SettingsBase.Platform is SettingsBase.PlatformType.Android)
                _result = element.GetAttribute("text");
            else
                _result = element.GetAttribute("text");
            return _result.Equals("on", StringComparison.OrdinalIgnoreCase);
        }

        // Custom exception class for element visibility issues
        public class ElementVisibilityException : Exception
        {
            public ElementVisibilityException(string message) : base(message)
            {
            }
        } 
        public void TakeScreenshot(string screenshotName)
        {
            try
            {
                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                directoryPath =  Path.Combine(directoryPath, screenshotName);
                Directory.CreateDirectory(directoryPath);

                var screenshotFiles = new List<string>();
                bool hasMoreContent = true;
                int screenshotIndex = 0;
                while (hasMoreContent)
                {
                    string screenshotFilePath = Path.Combine(directoryPath, $"{screenshotName}_{screenshotIndex++}.png");
                    var screenshot = driver.GetScreenshot();
                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                    screenshotFiles.Add(screenshotFilePath);
                    ScrollUsingPointer();
                    if (screenshotFiles.Count > 1 && CompareScreenshots(screenshotFiles[screenshotFiles.Count - 2],screenshotFilePath))
                    {
                        Console.WriteLine("Reached the end of the page or same screenshot taken.");
                        hasMoreContent = false;
                        screenshotFiles.Remove(screenshotFilePath);
                        // Brief delay to ensure file system release
                        Task.Delay(500).Wait();
                        //For deleting already existed duplicate ScreenShot
                        File.Delete(screenshotFilePath);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Thrown exception : " + e);
            }
        }
        public static bool CompareScreenshots(string screenshotPath1, string screenshotPath2)
        {
            using (Image<Rgba32> image1 = Image.Load<Rgba32>(screenshotPath1))
            using (Image<Rgba32> image2 = Image.Load<Rgba32>(screenshotPath2))
            {
                // Calculate the percentage difference threshold
                double threshold = 0.01; // 1% difference threshold

                // Compare images pixel by pixel
                bool areEqual = CompareImagesPixelByPixel(image1, image2, threshold);

                return areEqual;
            }
        }

        private static bool CompareImagesPixelByPixel(Image<Rgba32> image1, Image<Rgba32> image2, double threshold)
        {
            // Ensure both images have the same dimensions
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                throw new ArgumentException("Images must have the same dimensions.");
            }

            int width = image1.Width;
            int height = image1.Height;
            int differentPixels = 0;

            // Iterate through each pixel and compare
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!ArePixelsSimilar(image1[x, y], image2[x, y], threshold))
                    {
                        differentPixels++;
                        // Optionally, you could log or handle differences here
                    }
                }
            }

            // Calculate the percentage of different pixels
            double diffPercentage = (double)differentPixels / (width * height);

            // You can adjust the threshold as needed
            return diffPercentage <= threshold;
        }

        private static bool ArePixelsSimilar(Rgba32 pixel1, Rgba32 pixel2, double threshold)
        {
            // Compare RGBA values of two pixels
            // Example: compare based on color difference
            int colorDifferenceThreshold = 30; // Adjust based on your requirements

            int rDiff = Math.Abs(pixel1.R - pixel2.R);
            int gDiff = Math.Abs(pixel1.G - pixel2.G);
            int bDiff = Math.Abs(pixel1.B - pixel2.B);

            return rDiff + gDiff + bDiff < colorDifferenceThreshold;
        }
        
        private void AddSwipeActions(ActionSequence actionSequence, PointerInputDevice pointerInputDevice, int startX, int startY, int endX, int endY)
        {
            actionSequence.AddAction(pointerInputDevice.CreatePointerMove(0, startX, startY, TimeSpan.FromSeconds(1)));
            actionSequence.AddAction(pointerInputDevice.CreatePointerDown((MouseButton)PointerButton.MiddleMouse));
            actionSequence.AddAction(pointerInputDevice.CreatePointerMove(0, endX, endY, TimeSpan.FromSeconds(1)));
            actionSequence.AddAction(pointerInputDevice.CreatePointerUp((MouseButton)PointerButton.MiddleMouse));
        }
       
        
        #endregion
        
    }
}