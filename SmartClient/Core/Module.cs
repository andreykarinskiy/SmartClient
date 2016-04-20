namespace Core
{
    using Prism.Events;
    using Prism.Logging;
    using Prism.Modularity;
    using Prism.Regions;

    public abstract class Module : IModule
    {
        protected readonly ILoggerFacade logger;
        protected readonly IRegionManager regionManager;
        protected readonly IEventAggregator eventAggregator;

        protected Module(ILoggerFacade logger, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.logger = logger;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
        }

        void IModule.Initialize()
        {
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(x =>
            //{
            //    var viewName = x.FullName;
            //    viewName = viewName.Replace(".Views.", ".ViewModels.");
            //    var viewAssemblyName = x.GetTypeInfo().Assembly.FullName;
            //    var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
            //    var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
            //    return Type.GetType(viewModelName);
            //});

            logger.Info($"Module {this.Description()} loaded.");

            Initialize();
        }

        protected abstract void Initialize();
    }
}
