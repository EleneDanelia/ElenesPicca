using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestAppMT.Data.Models;

namespace RazorPagesTestAppMT.Pages
{
    public class CustomBurgerModel : PageModel
    {
        [BindProperty]
        public Data.Models.BurgerModel Burger { get; set; }
        public float BurgerPrice { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            BurgerPrice = Burger.BasePrice;

            if (Burger.TomatoSauce) BurgerPrice += 1;
            if (Burger.Cheese) BurgerPrice += 1;
            if (Burger.Mushroom) BurgerPrice += 1;
            if (Burger.Ham) BurgerPrice += 1;
            if (Burger.Beef) BurgerPrice += 1;

            return RedirectToPage("Checkout", new { Burger.BurgerName, BurgerPrice });
        }
    }
}
