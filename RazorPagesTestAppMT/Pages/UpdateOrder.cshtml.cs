using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestAppMT.Data.Models;
using RazorPagesTestAppMT.Data.Models.DbModels;

namespace RazorPagesTestAppMT.Pages
{
    public class UpdateOrderModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpdateOrderModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        [BindProperty]
        public string NewBurgerName { get; set; }

        [BindProperty]
        public float NewBurgerPrice { get; set; }

        [BindProperty]
        public List<string> SelectedIngredients { get; set; }

        public List<string> AllIngredients { get; } = new List<string> { "Tomato Sauce", "Cheese", "Pepperoni", "Mushroom", "Tuna", "Ham", "Beef" };

        public IActionResult OnGet()
        {
            var order = _db.BurgerOrders.Find(OrderId);
            if (order == null)
            {
                return RedirectToPage("/NotFoundPage");
            }

            NewBurgerName = order.BurgerName;
            NewBurgerPrice = (float)order.BurgerPrice;
            SelectedIngredients = AllIngredients.Where(ingredient => IsIngredientSelected(order, ingredient)).ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            var order = _db.BurgerOrders.Find(OrderId);
            if (order == null)
            {
                return RedirectToPage("/NotFoundPage");
            }

            order.BurgerName = NewBurgerName;

            NewBurgerPrice = CalculateBurgerPrice();

            order.BurgerPrice = NewBurgerPrice;

            foreach (var ingredient in AllIngredients)
            {
                SetIngredientValue(order, ingredient, SelectedIngredients.Contains(ingredient));
            }

            _db.SaveChanges();

            return RedirectToPage("/Order");
        }
        private float CalculateBurgerPrice()
        {
            float burgerPrice = 0;


            if (SelectedIngredients.Contains("Tomato Sauce"))
                burgerPrice += 1;
            if (SelectedIngredients.Contains("Cheese"))
                burgerPrice += 2;
            if (SelectedIngredients.Contains("Pepperoni"))
                burgerPrice += 2;
            if (SelectedIngredients.Contains("Mushroom"))
                burgerPrice += 1;
            if (SelectedIngredients.Contains("Tuna"))
                burgerPrice += 1;
            if (SelectedIngredients.Contains("Ham"))
                burgerPrice += 4;
            if (SelectedIngredients.Contains("Beef"))
                burgerPrice += 3;

            return burgerPrice;
        }


        private bool IsIngredientSelected(BurgerOrder order, string ingredient)
        {
            return (bool)typeof(BurgerOrder).GetProperty(ingredient.Replace(" ", "")).GetValue(order);
        }

        private void SetIngredientValue(BurgerOrder order, string ingredient, bool value)
        {
            typeof(BurgerOrder).GetProperty(ingredient.Replace(" ", "")).SetValue(order, value);
        }
    }
}
