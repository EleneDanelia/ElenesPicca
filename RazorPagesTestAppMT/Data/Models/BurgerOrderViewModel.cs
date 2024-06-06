using System.Text;

namespace RazorPagesTestAppMT.Data.Models
{
    public class BurgerOrderViewModel
    {
        public int Id { get; set; }
        public string BurgerName { get; set; }
        public float BurgerPrice { get; set; }
        public StringBuilder Ingredients { get; set; }
    }
}
