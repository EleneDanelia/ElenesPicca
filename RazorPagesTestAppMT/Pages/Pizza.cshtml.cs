using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestAppMT.Data.Models;

namespace RazorPagesTestAppMT.Pages
{
    public class BurgerModel : PageModel
    {
        public List<Data.Models.BurgerModel> fakeBurgerDB = new List<Data.Models.BurgerModel>()
        {
            new Data.Models.BurgerModel(){
                ImageTitle="Margerita",
                BurgerName="Margerita",
                BasePrice=2,
                TomatoSauce=true,
                Cheese=true,
                FinalPrice=4},
            new Data.Models.BurgerModel(){ ImageTitle="Bolognese", BurgerName="Bolognese", BasePrice=2, TomatoSauce=true, Cheese=true, Beef=true, FinalPrice=5},
            new Data.Models.BurgerModel(){ ImageTitle="Hawaiian", BurgerName="Hawaiian", BasePrice=2, TomatoSauce=true, Cheese=true, Ham=true, Pineapple=true, FinalPrice=15},
            new Data.Models.BurgerModel(){ ImageTitle="Carbonara", BurgerName="Carbonara", BasePrice=2, TomatoSauce=true, Cheese=true, Ham=true, Mushroom=true, FinalPrice=6},
            new Data.Models.BurgerModel(){ ImageTitle="MeatFeast", BurgerName="MeatFeast", BasePrice=2, TomatoSauce=true, Cheese=true, Ham=true, Beef=true, FinalPrice=6},
            new Data.Models.BurgerModel(){ ImageTitle="Mushroom", BurgerName="Mushroom", BasePrice=2, TomatoSauce=true, Cheese=true, Mushroom=true, FinalPrice=5},
            new Data.Models.BurgerModel(){ ImageTitle="Pepperoni", BurgerName="Pepperoni", BasePrice=2, TomatoSauce=true, Cheese=true, Peperoni=true, FinalPrice=5},
            new Data.Models.BurgerModel(){ ImageTitle="Seafood", BurgerName="Seafood", BasePrice=2, TomatoSauce=true, Cheese=true, Tuna=true, FinalPrice=5},
            new Data.Models.BurgerModel(){ ImageTitle="Vegetarian", BurgerName="Vegetarian", BasePrice=2, TomatoSauce=true, Cheese=true, Mushroom=true, Pineapple=true, FinalPrice=12},

        };
        public void OnGet()
        {
        }
    }
}
