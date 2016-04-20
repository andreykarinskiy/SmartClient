namespace ExampleModule
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Reflection;

    using Core;

    using ExampleModule.Views;

    using Prism.Events;
    using Prism.Logging;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Regions;

    using Module = Core.Module;

    [Description("Example")]
    public class ExampleModuleInitializer : Module
    {
        public ExampleModuleInitializer(ILoggerFacade logger, IRegionManager regionManager, IEventAggregator eventAggregator) : base(logger, regionManager, eventAggregator)
        {
        }

        protected override void Initialize()
        {
            regionManager.RegisterViewWithRegion("Example", typeof(ExampleView));
        }
    }
}
