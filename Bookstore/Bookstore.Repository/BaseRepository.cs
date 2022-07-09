using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels;

namespace Bookstore.Repository
{
    public class BaseRepository
    {
        protected readonly bookStoreContext _context = new bookStoreContext();
    }
}
