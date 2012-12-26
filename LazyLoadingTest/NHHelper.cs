namespace LazyLoadingTest
{
    using System;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

    public class NHHelper
    {
        private static ISessionFactory _sessionFactory;

        public static void ShowAllDataUsingNh()
        {
            if (_sessionFactory == null)
            {
                InitSessionFactory();
            }

            using (var session = _sessionFactory.OpenSession())
            {
                foreach (var order in session.CreateCriteria<Order>().List<Order>())
                {
                    Console.WriteLine("Order {0}, Customer {1}", order.Description, order.Customer.Id);
                }
            }
        }

        public static void InitNHData()
        {
            if (_sessionFactory == null)
            {
                InitSessionFactory();
            }

            using (var session = _sessionFactory.OpenSession())
            {
                var customer1 = new Customer() { Id = Guid.NewGuid(), Name = "Customer1" };
                var customer2 = new Customer() { Id = Guid.NewGuid(), Name = "Customer2" };
                var customer3 = new Customer() { Id = Guid.NewGuid(), Name = "Customer3" };
                session.Save(customer1);
                session.Save(customer2);
                session.Save(customer3);

                session.Save(new Order() { Id = Guid.NewGuid(), Description = "Description1", Customer = customer1 });
                session.Save(new Order() { Id = Guid.NewGuid(), Description = "Description2", Customer = customer2 });
                session.Save(new Order() { Id = Guid.NewGuid(), Description = "Description3", Customer = customer3 });
                session.Save(new Order() { Id = Guid.NewGuid(), Description = "Description4", Customer = customer1 });
                session.Save(new Order() { Id = Guid.NewGuid(), Description = "Description5", Customer = customer2 });
                session.Save(new Order() { Id = Guid.NewGuid(), Description = "Description6", Customer = customer3 });

                session.Flush();
                session.Close();
            }
        }

        private static void InitSessionFactory()
        {
            _sessionFactory =
                Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestNH;Integrated Security=SSPI"))
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Customer>()
                            .Where(type => type.Equals(typeof(Customer)) || type.Equals(typeof(Order)))
                         ))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }
    }
}
