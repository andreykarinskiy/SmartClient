namespace ExampleModule
{
    using System;
    using System.ComponentModel;

    using Core;

    using Prism.Events;
    using Prism.Logging;
    using Prism.Modularity;
    using Prism.Regions;

    [Description("Example")]
    public class ExampleModuleInitializer : IModule
    {
        private readonly ILoggerFacade logger;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public ExampleModuleInitializer(ILoggerFacade logger, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.logger = logger;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            this.logger.Info($"Загружен модуль {this.Description()}.");
        }
    }
}
