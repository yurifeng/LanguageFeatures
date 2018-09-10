namespace LanguageFeatures.Models
{

    /// <summary>
    /// Product实体类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// _name字段
        /// </summary>
        private string _name;

        /// <summary>
        /// 自动属性(ProductId)
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 自动属性(Name)
        /// </summary>
        public string Name
        {
            //设置得到的Product的Name是id与name的组合
            get => ProductId + _name;
            set => _name = value;
        }

        /// <summary>
        /// 自动属性(Price)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 自动属性(Category)
        /// </summary>
        public string Category { set; get; }

        /// <summary>
        /// 自动属性(Description)
        /// </summary>
        public string Description { get; set; }
    }
}
