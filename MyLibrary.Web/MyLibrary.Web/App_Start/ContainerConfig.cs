using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using System.Reflection;
using Infrastructure.QueryBase;
using Infrastructure.CommandBase;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Autofac.Extras.CommonServiceLocator;
using MyLibrary.Queries;
using MyLibrary.Models;
using MyLibrary.Commands;

namespace MyLibrary.Web
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<InMemoryBookRepository>().As<IBookRepository>().SingleInstance();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<WhatsHotQueryHandler>().As<IQueryHandler<WhatsHotQuery, WhatsHotQueryResult>>();
            builder.RegisterType<CreateBookCommandHandler>().As<ICommandHandler<CreateBookCommand>>();
            var container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}