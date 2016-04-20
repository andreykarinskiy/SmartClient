namespace Shell
{
    using System;
    using System.Windows;

    public partial class App : Application
    {
        private readonly ShellBootsrapper bootstrapper;

        public App()
        {
            bootstrapper = new ShellBootsrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                bootstrapper.Run();
            }
            catch (Exception exception)
            {
                HandleError(exception);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            CleanupAndExit(fail: false);
        }

        private void HandleError(Exception exception)
        {
            ReportError(exception);

            CleanupAndExit(fail: true);
        }

        private static void ReportError(Exception exception)
        {
            //TODO: Вызов модального диалогового окна или запись в журнал.
        }

        private void CleanupAndExit(bool fail)
        {
            bootstrapper.Dispose();

            if (fail)
            {
                Environment.FailFast("Application initialization failed.");
            }
        }
    }
}
