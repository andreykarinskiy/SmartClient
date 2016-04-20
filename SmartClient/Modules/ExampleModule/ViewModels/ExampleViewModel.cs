using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleModule.ViewModels
{
    using Core;

    using Prism.Mvvm;

    public class ExampleViewModel : ViewModel
    {
        private string message;

        public ExampleViewModel()
        {
            Message = "Hello from module";
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                SetProperty(ref message, value);
            }
        }
    }
}
