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
                ImageTitle="burger",
                BurgerName="burger",
                BasePrice=2,
                TomatoSauce=true,
                Cheese=true,
                FinalPrice=4},
            new Data.Models.BurgerModel(){ ImageTitle="beef", BurgerName="beef", BasePrice=2, Beef=true, FinalPrice=2},
            new Data.Models.BurgerModel(){ ImageTitle="cheese", BurgerName="cheese", BasePrice=2, Cheese=true, FinalPrice=4},
            new Data.Models.BurgerModel(){ ImageTitle="mushrooms", BurgerName="mushrooms", BasePrice=2, TomatoSauce=true, Cheese=true, Mushroom=true, FinalPrice=5},
            new Data.Models.BurgerModel(){ ImageTitle="coca cola", BurgerName="coca cola", BasePrice=2, FinalPrice=3},
            new Data.Models.BurgerModel(){ ImageTitle="ham", BurgerName="ham", BasePrice=2, FinalPrice=5},
            new Data.Models.BurgerModel(){ ImageTitle="free", BurgerName="free", BasePrice=2, TomatoSauce=true, FinalPrice=4},

        };
        public void OnGet()
        {
        }
    }
}
