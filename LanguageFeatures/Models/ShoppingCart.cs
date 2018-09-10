using System.Collections;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{

    /// <summary>
    /// ShoppingCart继承IEnumerable接口(里面的类型是Product)
    /// </summary>
    public class ShoppingCart : IEnumerable<Product>
    {

        /// <summary>
        /// 将Product的list集合作为ShoppingCart的属性
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// 重写接口方法
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Product> GetEnumerator()
        {
            return Products.GetEnumerator();
        }

        /// <summary>
        /// 重写接口方法
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
