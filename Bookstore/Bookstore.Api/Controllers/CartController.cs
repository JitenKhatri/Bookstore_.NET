using System.Collections.Generic;
using System.Linq;
using Bookstore.Models.Models;
using Bookstore.Models.ViewModels;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly CartRepository _cartRepository = new();

        [HttpGet]
        [Route("list/{id}")]
        /*public IActionResult GetCartItems(string keyword)
        {
            List<Cart> carts = _cartRepository.GetCartItems(keyword);
            IEnumerable<CartModel> cartModels = carts.Select(c => new CartModel(c));
            return Ok(cartModels);
        } */
        public IActionResult GetCartItems(int id, int pageindex = 1, int pagesize = 10)
        {
            var cartItems = _cartRepository.GetCartItems(id, pageindex, pagesize);
            ListResponse<CartModel> listResponse = new ListResponse<CartModel>()
            {
                Results = cartItems.Results.Select(c => new CartModel(c)),
                TotalRecords = cartItems.TotalRecords,
                
            };
            return Ok(listResponse);
        }


        [HttpPost]
        [Route("add")]
        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.AddCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.UpdateCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest();

            bool response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
} 

