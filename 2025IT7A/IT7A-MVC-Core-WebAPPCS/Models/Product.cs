using System.Text.Json.Serialization;

namespace IT7A_MVC_Core_WebAPPCS.Models
{
    [JsonSerializable(typeof(Product))]
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Rate { get; set; }
        public string Description { get; set; }

    }
}
