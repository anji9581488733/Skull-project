using System;
using OpenQA.Selenium;

namespace Polaris.Base
{
    /// <summary>
    ///     Shared ControlBase for all Xamarin test targets.
    ///     Test target specific app functions are implemented in the individual projects.
    ///     This class should never be instantiated.
    /// </summary>
    public abstract class ControlBase : PageBase
    {
        public static IWebElement element;


        /// <summary>
        ///     Element is clickable function
        /// </summary>
        // Isnt in use anywhere and calls Enabled directly.
        public virtual bool IsClickable => false;


        public bool IsElementDisplayed()
        {
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
    }
}