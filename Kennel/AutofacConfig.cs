using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public static class AutofacConfig
    {
        public static IContainer Configure()
        {
            //builds container
            var builder = new ContainerBuilder();
            
            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<Factory>().As<IFactory>();
            builder.RegisterType<Animal>().As<IAnimal>();
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<PersonManager>().As<IPersonManager>();
            builder.RegisterType<AnimalManager>().As<IAnimalManager>();
            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<DataRepository>().As<IDataRepository>();
            builder.RegisterType<ListDatabase>().As<IListDatabase>().SingleInstance();

            return builder.Build();
        }
    }
}
