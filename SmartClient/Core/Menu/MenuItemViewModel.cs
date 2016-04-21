namespace Core.Menu
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Prism.Commands;

    public class MenuItemViewModel
    {
        public MenuItemViewModel()
        {
            this.Command = new DelegateCommand(Execute);
        }

        public string Header { get; set; }

        public IEnumerable<MenuItemViewModel> MenuItems { get; set; }

        public ICommand Command { get; }

        private void Execute()
        {
        }
    }
}
