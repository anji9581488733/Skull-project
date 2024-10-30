using Gleipner.Base;
using Gleipner.Controls;
using Gleipner.Controls.Button;
using OpenQA.Selenium;

namespace Gleipner.Pages.MyResound.GuidingTips
{
    /// <summary>
    ///     Class is only used internally in Gleipner. Can not be instantiated externally.
    /// </summary>
    public class GuidingTipsNudgingBaseDialog : PageBase
    {
        internal GuidingTipsNudgingBaseDialog()
        {
        }

        public IWebElement BackToTips => new Buttons().NudgingTipBackToArchiveButton;
        public IWebElement GotIt => new Buttons().NudgingTipConfirmButton;
    }
}