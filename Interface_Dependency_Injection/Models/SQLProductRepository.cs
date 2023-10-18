using Microsoft.EntityFrameworkCore;

namespace Interface_Dependency_Injection.Models
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly iakademi47Context context; //this.context

        public SQLProductRepository(iakademi47Context context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }

        public Product GetProduct(int id)
        {
            // return context.tbl_Products.Find(id);


            //stored procedure
            return context.Products.FromSqlRaw<Product>("spGetProductByID {0}", id).ToList().FirstOrDefault();
        }

        public Product Add(Product newProduct)
        {
            /*
            context.tbl_Products.Add(newProduct);
            context.SaveChanges();
            return newProduct;
            */

            //stored procedure
            context.Database.ExecuteSqlRaw("SpInsertProduct {0},{1},{2}", newProduct.Name, newProduct.Quantity, newProduct.Category);

            return newProduct;
        }

        public Product Delete(int id)
        {
            Product productDelete = context.Products.Find(id);
            if (productDelete != null)
            {
                context.Products.Remove(productDelete);
                context.SaveChanges();
            }
            return productDelete;
        }



        public Product Update(Product updateProduct)
        {
            var product = context.Products.Attach(updateProduct);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateProduct;
        }
    }
}
