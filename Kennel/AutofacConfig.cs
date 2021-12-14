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
            
            //Main
            builder.RegisterType<Application>().As<IApplication>();

            //Classes
            builder.RegisterType<Factory>().As<IFactory>();
            builder.RegisterType<Animal>().As<IAnimal>();
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<CreatePerson>().As<ICreatePerson>();
            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<CustomerList>().As<ICustomerList>().SingleInstance();
            builder.RegisterType<AnimalList>().As<IAnimalList>().SingleInstance();


            return builder.Build();
        }
    }
}
