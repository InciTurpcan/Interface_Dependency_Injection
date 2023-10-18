namespace Interface_Dependency_Injection.Models
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts(); //  all product list

		Product GetProduct(int id); // details

		Product Delete(int id); // delete
		
		Product Add(Product newProduct); //insert
		Product Update(Product updateProduct); // update
		
	}
}
