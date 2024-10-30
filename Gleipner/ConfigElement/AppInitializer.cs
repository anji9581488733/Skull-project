namespace Gleipner.ConfigElement
{
    public class AppInitializer : Polaris.Base.AppInitializer
    {
        #region Initialize settings

        /// <summary>
        ///     Initialize all settings, app specific and generic alike, prior to starting the app.
        /// </summary>
        public new static void InitializeSettings()
        {
            var settings = new Settings();
            settings.InitializeSettings();
        }

        #endregion Initialize settings
    }
}