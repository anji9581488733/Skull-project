using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.Cards.TopPricePoint
{
    public class AllAroundCard : Card
    {
        public IWebElement NoiseFilter => new Buttons().SmartButtonAllAroundNoiseFilter;
        public IWebElement SpeechClarity => new Buttons().SmartButtonAllAroundSpeechClarity;
        public IWebElement AllAround => new Buttons().AllAround;

        // These parameters are not tested in the cards page object tests.
        public bool NoiseFilterActivated => new Buttons().SmartButtonAllAroundNoiseFilterSelected;
        public bool SpeechClarityActivated => new Buttons().SmartButtonAllAroundSpeechClaritySelected;
    }
}