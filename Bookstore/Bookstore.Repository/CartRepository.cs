using System.Collections.Generic;
using System.Linq;
using Bookstore.Models.Models;
using Bookstore.Models.ViewModels;
using Bookstore.Repository;
using Microsoft.EntityFrameworkCore;

 namespace Bookstore.Repository
{
    public class CartRepository : BaseRepository
    {
        /*public List<Cart> GetCartItems(string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Carts.Include(c => c.Book).Where(c => keyword == null || c.Book.Name.ToLower().Contains(keyword)).AsQueryable();
            return query.ToList();
        }  */
        public ListResponse<Cart> GetCartItems(int id, int pageindex = 1, int pagesize = 10)
        {
            var query = _context.Carts.Include(c => c.Book).Where(c => c.Userid.Equals(id)).AsQueryable();
            var total = query.Count();
            List<Cart> carts = query.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return new ListResponse<Cart>()
            {
                TotalRecords = total,
                Results = carts
            };

        }


        public Cart GetCarts(int id)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == id);
        }

        public Cart AddCart(Cart category)
        {
            var entry = _context.Carts.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Cart UpdateCart(Cart category)
        {
            var entry = _context.Carts.Update(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }
    }
} 

