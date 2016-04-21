namespace Shell.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Core;
    using Core.Menu;
    using Prism.Logging;


    public class ShellViewModel : ViewModel
    {
        private readonly ILoggerFacade logger;

        public ShellViewModel(ILoggerFacade logger)
        {
            this.logger = logger;

            Title = "Preved!";

            this.MenuItems = new ObservableCollection<MenuItemViewModel>
                             {
                                 new MenuItemViewModel {Header = "File"},
                                 new MenuItemViewModel {Header = "Edit"},
                                 new MenuItemViewModel {Header = "Help"},
                             };
        }

        public virtual string Title { get; set; }

        public virtual IEnumerable<MenuItemViewModel> MenuItems { get; set; }

        public void Wrap()
        {

        }
    }
}
