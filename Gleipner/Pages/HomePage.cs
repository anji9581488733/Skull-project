using Gleipner.Base;
using Gleipner.Pages.Cards.TopPricePoint;

// Demo version of Home page.
namespace Gleipner.Pages
{
    public class HomePage : PageBase
    {
        public AllAroundCard allAroundCard;
        public BottomRibbonBar bottomRibbonBar;

        public DialogPage demoDialog;
        public TopRibbonBar topRibbonBar;

        public HomePage()
        {
            bottomRibbonBar = new BottomRibbonBar();
            topRibbonBar = new TopRibbonBar();
            allAroundCard = new AllAroundCard();

            demoDialog = new DialogPage();
        }
    }
}