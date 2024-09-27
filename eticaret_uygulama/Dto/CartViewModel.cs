using eticaret_uygulama.Models;

namespace eticaret_uygulama.Dto
{
    public class CartViewModel
    {
        public List<CartItem> ? CartItems { get; set; }
        public decimal GrandTotal { get; set; }
    }
}