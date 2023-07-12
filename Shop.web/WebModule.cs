using Autofac;
using Autofac.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Shop.web.Repositories;
using Shop.web.Repository;
using System;

internal class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        /*
        //It means that a new instance of the service will be created each time it is requested
        builder.RegisterType<MyService>().InstancePerDependency(); 
        //It means that a single instance of the service is created per lifetime scope.
        builder.RegisterType<MyScopedService>().InstancePerLifetimeScope(); 
        //It means that only one instance of the service is created and shared throughout the application.
        builder.RegisterType<MySingletonService>().SingleInstance(); 
        */

        builder.RegisterType<ProductRepository>().InstancePerDependency();
        builder.RegisterType<SalesSummaryRepository>().InstancePerDependency();
        builder.RegisterType<SalesDetailsRepository>().InstancePerDependency();
        base.Load(builder);
    }
}