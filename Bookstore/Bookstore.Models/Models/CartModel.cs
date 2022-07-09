﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models.ViewModels;

namespace Bookstore.Models.Models
{
    public class CartModel
    {
            public CartModel() { }

            public CartModel(Cart cart)
            {
              
                Id = cart.Id;
                Userid = cart.Userid;
                Bookid = cart.Bookid;
                Quantity = cart.Quantity;
               
            }
            public int Id { get; set; }
        public int Userid { get; set; }
        public int Bookid { get; set; }
        public int Quantity { get; set; }
        public virtual Book book { get; set; }
    }
}
