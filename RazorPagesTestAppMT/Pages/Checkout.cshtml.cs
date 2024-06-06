using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTestAppMT.Data.Models;
using RazorPagesTestAppMT.Data.Models.DbModels;

namespace RazorPagesTestAppMT.Pages
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public string BurgerName { get; set; }
        public float BurgerPrice { get; set; }
        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context;

        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(BurgerName))
            {
                BurgerName = "Custom";
            }

            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            BurgerOrder BurgerOrder = new BurgerOrder();
            BurgerOrder.BurgerName = BurgerName;
            BurgerOrder.BurgerPrice = BurgerPrice;

            _context.BurgerOrders.Add(BurgerOrder);
            _context.SaveChanges();
        }
    }
}
