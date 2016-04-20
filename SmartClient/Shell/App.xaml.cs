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
                bootstrapper.Run(e.Args);
            }
            catch (Exception exception)
            {
                HandleError(exception);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            CleanupAndExit();
        }

        private void HandleError(Exception exception)
        {
            bootstrapper.ReportError(exception);

            ReportError(exception);

            CleanupAndExit();
        }

        private static void ReportError(Exception exception)
        {
            //TODO: Вызов модального диалогового окна или запись в журнал.
        }

        private void CleanupAndExit()
        {
            bootstrapper.Dispose();
        }
    }
}
