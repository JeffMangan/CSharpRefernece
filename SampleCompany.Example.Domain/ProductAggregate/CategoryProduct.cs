namespace SampleCompany.Domain
{
    public class CategoryProduct
    {
        public System.Guid Id { get; set; }
        public System.Guid ProductCategoryId { get; set; }
        public System.Guid ProductId { get; set; }
    }
}