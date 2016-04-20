namespace Shell.ViewModels
{
    using Core;

    using Prism.Logging;
    using Prism.Mvvm;

    public class ShellViewModel : ViewModel
    {
        private readonly ILoggerFacade logger;

        public ShellViewModel(ILoggerFacade logger)
        {
            this.logger = logger;

            Title = "Preved!";
        }

        public string Title { get; set; }
    }
}
