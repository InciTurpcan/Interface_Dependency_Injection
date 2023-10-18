namespace Interface_Dependency_Injection.Models
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> _productsList;

        public ProductRepository()
        {
			_productsList = new List<Product>()
			{
				new Product() {ID=1, Name="Television" ,Quantity=20000, Category ="Electronic"},
				new Product() {ID=2, Name="Telephone" ,Quantity=20000, Category ="Electronic"},
				new Product() {ID=3, Name="Table" ,Quantity=20000, Category ="Furniture"},
				new Product() {ID=1, Name="Freezer" ,Quantity=20000, Category ="Household Appliances"},
				new Product() {ID=1, Name="Washing Machine" ,Quantity=20000, Category ="Household Appliances"}


			};
        }
        public Product Add(Product newProduct)
		{
			_productsList.Add(newProduct);
			return newProduct;
		}

		public Product Delete(int id)
		{
			Product productDelete = _productsList.FirstOrDefault(p => p.ID == id);
			if (productDelete != null) 
			{
			 _productsList.Remove(productDelete);
			}
			return productDelete;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _productsList.ToList();
		}

		public Product GetProduct(int id)
		{
			return _productsList.FirstOrDefault(p => p.ID == id);

		}

		public Product Update(Product updateProduct)
		{
			throw new NotImplementedException();
		}
	}
}
