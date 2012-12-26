namespace LazyLoadingTest
{
    using System;
    using System.Data.Entity;

    public class EFHelper
    {
        public static void ShowAllDataUsingEf()
        {
            using (var context = new LazyLoadingEfContext())
            {
                foreach (var order in context.Orders)
                {
                    Console.WriteLine("Order {0}, Customer {1}", order.Description, order.Customer.Id);
                }
            }
        }

        public static void InitEFData()
        {
            using (var context = new LazyLoadingEfContext())
            {
                var customer1 = new Customer() { Id = Guid.NewGuid(), Name = "Customer1" };
                var customer2 = new Customer() { Id = Guid.NewGuid(), Name = "Customer2" };
                var customer3 = new Customer() { Id = Guid.NewGuid(), Name = "Customer3" };
                context.Customer.Add(customer1);
                context.Customer.Add(customer2);
                context.Customer.Add(customer3);

                context.Orders.Add(new Order() { Id = Guid.NewGuid(), Description = "Description1", Customer = customer1 });
                context.Orders.Add(new Order() { Id = Guid.NewGuid(), Description = "Description2", Customer = customer2 });
                context.Orders.Add(new Order() { Id = Guid.NewGuid(), Description = "Description3", Customer = customer3 });
                context.Orders.Add(new Order() { Id = Guid.NewGuid(), Description = "Description4", Customer = customer1 });
                context.Orders.Add(new Order() { Id = Guid.NewGuid(), Description = "Description5", Customer = customer2 });
                context.Orders.Add(new Order() { Id = Guid.NewGuid(), Description = "Description6", Customer = customer3 });

                context.SaveChanges();
            }
        }
    }

    public class LazyLoadingEfContext : DbContext
    {
        public LazyLoadingEfContext()
            : base("LazyLoadingEFContext")
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customer { get; set; }
    }

}
