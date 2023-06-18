using OnlineShop230616.Models;
using System.ComponentModel;

namespace OnlineShop230616.ViewModels
{
    public class ProductViewModel : BaseModel
    {
        //public ProductViewModel() { }
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Price")]
        public double Price { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public ResponseModel response { get; set; }
    }
}
