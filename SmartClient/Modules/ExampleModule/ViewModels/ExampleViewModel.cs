namespace ExampleModule.ViewModels
{
    using Core;

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
