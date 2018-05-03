namespace WorkingWithVisualStudio.Models
{
	using System.Collections.Generic;

	public class SimpleRepository
	{
		private static SimpleRepository sharedRepository = new SimpleRepository();
		private Dictionary<string, Product> products = new Dictionary<string, Product>();

		public static SimpleRepository SharedRepository => sharedRepository;

		public SimpleRepository()
		{
			var initialItems = new[]
				                   {
					                   new Product { Name = "Kayak", Price = 275M },
									   new Product { Name = "Lifejacket", Price = 48.95M },
									   new Product { Name = "Soccer ball", Price = 19.50M },
									   new Product { Name = "Corner flag", Price = 34.95M }
				                   };
			foreach (var p in initialItems)
			{
				AddProduct(p);
			}
			this.products.Add("Error", null);
		}

		public IEnumerable<Product> Products => this.products.Values;

		public void AddProduct(Product p) => this.products.Add(p.Name, p);
	}
}