using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Service{
    public class ProductService{
        public List<Product> products = new List<Product>();
        public ProductService(){
            // Bình thường sẽ Inj Context vào trong đây
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product();
                product.ID = i+ 1;
                product.Name = "Sản Phẩm "+ (i+1);
                product.Price = 100+ i*10;
                products.Add(product);
            }

        }


    }
}