using System;
using Gleipner.Controls.Text;
using HearingInstrumentControllerService;
using OpenQA.Selenium;

namespace Gleipner.Base
{
    /// <summary>
    ///     App specific PageBase
    /// </summary>
    public class PageBase : Polaris.Base.PageBase
    {
        public static HicServiceClient hics;
        public string AppNameInfo => new Texts().AppName;
        public string AppVersionBuildInfo => new Texts().AppVersionBuild;
    }
}