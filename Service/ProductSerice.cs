using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Service{
    public class ProductService{
        public List<ProductModel> products = new List<ProductModel>();
        public ProductService(){
            // Bình thường sẽ Inj Context vào trong đây
            for (int i = 0; i < 10; i++)
            {
                ProductModel product = new ProductModel();
                product.ID = i+ 1;
                product.Name = "Sản Phẩm "+ (i+1);
                product.Price = 100+ i*10;
                products.Add(product);
            }

        }


    }
}