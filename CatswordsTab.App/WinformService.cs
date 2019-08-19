﻿using CatswordsTab.App.Winform;

namespace CatswordsTab.App
{
    class WinformService
    {
        private static Main MainWindow;
        private static Expert ExpertWindow;
        private static Writer WriterWindow;

        public static void SetMainWindow(Main window)
        {
            MainWindow = window;
        }

        public static Main GetMainWindow()
        {
            return MainWindow;
        }

        public static Expert GetExpertWindow()
        {
            ExpertWindow = new Expert();
            return ExpertWindow;
        }

        public static Writer GetWriterWindow()
        {
            WriterWindow = new Writer();
            return WriterWindow;
        }
    }
}