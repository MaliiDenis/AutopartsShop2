namespace Motora.Domain.Models
{
    public class ProductFeature
    {
        public int ProductFeatureId { get; set; }
        public int ProductId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureValue { get; set; }

        // Навигационное свойство
        public virtual Product Product { get; set; }
    }
}