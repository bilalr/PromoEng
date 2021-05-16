namespace BR.PromoEng.Models
{
    /// <summary>
    /// abstraction for promotion 
    /// give a possiblity to extentions.
    /// </summary>
    public abstract class Promotion
    {
        public decimal price { get; set; }
        public PromotionType PromotionType { get; set; }
    }
    /// <summary>
    /// Type of promotions. 
    /// If new type come so need to add it here
    /// </summary>
    public enum PromotionType
    {
        IndividualSKU = 0,
        CombinedSKU = 1
    }
}