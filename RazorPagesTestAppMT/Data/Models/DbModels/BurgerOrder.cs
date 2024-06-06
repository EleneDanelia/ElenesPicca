namespace RazorPagesTestAppMT.Data.Models.DbModels
{
    public class BurgerOrder
    {
        public int Id { get; set; }
        public string BurgerName { get; set; }
        public double BurgerPrice { get; set; }
        public bool TomatoSauce { get; set; }
        public bool Cheese { get; set; }
        public bool Mushroom { get; set; }
        public bool Ham { get; set; }
        public bool Beef { get; set; }
    }
}

