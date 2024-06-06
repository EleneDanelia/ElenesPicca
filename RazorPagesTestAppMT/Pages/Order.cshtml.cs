using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestAppMT.Data.Models;
using RazorPagesTestAppMT.Data.Models.DbModels;
using System.Text;

namespace RazorPagesTestAppMT.Pages
{
    public class OrderModel : PageModel
    {
        public List<BurgerOrder> BurgerOrders { get; set; }
        public List<BurgerOrderViewModel> FiltereBurgerOrders { get; set; }
        private readonly ApplicationDbContext _db;
        private readonly IEnumerable<object> burgerOrders;
        private List<BurgerOrderViewModel> burgerOrderViewModels;

        public OrderModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            BurgerOrders = _db.BurgerOrders.ToList();

            FiltereBurgerOrders = GetBurgerOrderViewModel(BurgerOrders);

            ViewData["FilteredBurgerOrders"] = FiltereBurgerOrders;
            return Page();

        }

        public IActionResult OnPostDelete(int orderId)
        {
            var orderToDelete = _db.BurgerOrders.FirstOrDefault(x => x.Id == orderId);
            if (orderToDelete is null)
                return RedirectToPage("/NotFountPage");

            _db.BurgerOrders.Remove(orderToDelete);
            _db.SaveChanges();

            return RedirectToPage("Order");
        }


        public List<BurgerOrderViewModel> GetBurgerOrderViewModel(List<BurgerOrder> burgerOrders)
        {
            var burgerOrderViewModels = new List<BurgerOrderViewModel>();

            var ingredientProperties = typeof(BurgerOrder).GetProperties().Where(p => p.PropertyType == typeof(bool));

            foreach (var order in burgerOrders)
            {
                var burgerModel = new BurgerOrderViewModel()
                {
                    Id = order.Id,
                    BurgerPrice = (float)order.BurgerPrice,
                    BurgerName = order.BurgerName,
                    Ingredients = new StringBuilder()
                };

                foreach (var prop in ingredientProperties)
                {
                    var propValue = prop.GetValue(order);
                    if (propValue != null && (bool)propValue)
                    {
                        burgerModel.Ingredients.Append($"{prop.Name}, ");
                    }
                }
                if (burgerModel.Ingredients.Length != 0)
                {
                    burgerModel.Ingredients.ToString().TrimEnd();
                }
                burgerOrderViewModels.Add(burgerModel);
            }

            return burgerOrderViewModels;
        }

    }
}
