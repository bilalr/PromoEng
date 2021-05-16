namespace BR.PromoEng.Models
{
    public abstract class Promotion
    {
        public decimal price { get; set; }
        public PromotionType PromotionType { get; set; }
    }
    public enum PromotionType
    {
        IndividualSKU = 0,
        CombinedSKU = 1
    }
}