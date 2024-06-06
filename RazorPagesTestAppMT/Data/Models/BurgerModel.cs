namespace RazorPagesTestAppMT.Data.Models
{
    public class BurgerModel
    {
        public string ImageTitle { get; set; }
        public string BurgerName { get; set; }
        public float BasePrice { get; set; } = 2;
        public bool TomatoSauce { get; set; }
        public bool Cheese { get; set; }
        public bool Mushroom { get; set; }
        public bool Ham { get; set; }
        public bool Beef { get; set; }
        public float FinalPrice { get; set; }
    }

}
