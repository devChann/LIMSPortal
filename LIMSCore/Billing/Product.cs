using System;

namespace LIMSCore.Billing
{
	public class Product
	{
		public Guid ProductId { get; set; }
		public int Number { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
