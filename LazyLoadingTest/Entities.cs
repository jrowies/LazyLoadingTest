namespace LazyLoadingTest
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public virtual Guid Id { get; set; } // virtual for NH

        public virtual string Description { get; set; } // virtual for NH

        public virtual Customer Customer { get; set; }
    }

    public class Customer
    {
        public virtual Guid Id { get; set; } // virtual for NH

        public virtual string Name { get; set; } // virtual for NH
    }
}
