namespace CAT.DataRefresh.Domain
{
    public interface IProductRepository
    {
        public System.Guid  AddNewProduct(Product p);

        public bool ChangeProductPrice();

        System.Guid AddPart(ProductPart part);

        public bool DeleteProduct();

        public Product GetProductById(System.Guid id);
    }
}