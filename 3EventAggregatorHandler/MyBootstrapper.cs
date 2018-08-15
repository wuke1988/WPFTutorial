using Caliburn.Micro;
using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition;
using System.Reflection;

namespace _3EventAggregatorHandler
{
    public class MyBootstrapper: BootstrapperBase
    {
        private CompositionContainer _container; 
        public MyBootstrapper()
        {
            Initialize();
        }
        //用MEF组合部件
        protected override void Configure()
        {
            _container = new CompositionContainer(new AggregateCatalog(
                  AssemblySource.Instance.Select(x=>new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                ));
            //如果还有自己的部件都加在这个地方
            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);

            _container.Compose(batch);
        }
        //根据传过来的key或名称得到实例
        protected override object GetInstance(Type service, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(service):key;
            var exports = _container.GetExportedValues<object>(contract);
            if (exports.Any())
            {
                return exports.First();
            }
            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(service));
        }
        //将实例传递给 Ioc 容器，使依赖关系注入
        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }

    }
}
