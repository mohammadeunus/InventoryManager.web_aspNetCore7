using Autofac;
using Autofac.Core;

internal class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterType<TestClass>().As<ITestClass1>().InstancePerLifetimeScope(); 
          /*The code registers TestClass as the implementation of ITestClass1 in Autofac,
           *so when ITestClass1 is requested, Autofac will provide an instance of TestClass.*/

        //builder.RegisterType<IndexModel>().AsSelf(); //if wish to pass a model throgh DI
        /* RegisterType<IndexModel>(), it registers the IndexModel class as a dependency with Autofac.
         * .AsSelf(), it specifies that, Autofac will provide an instance of IndexModel when requested */

        base.Load(builder);
    }
}