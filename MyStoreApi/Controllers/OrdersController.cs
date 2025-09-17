using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStoreApi.Data;
using MyStoreApi.Models;

namespace MyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public OrdersController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.Customer)  // This joins with customer data!
                .ToListAsync();
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
    }
}