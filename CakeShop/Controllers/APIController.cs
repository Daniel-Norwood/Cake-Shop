//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using CakeShop.Persistence;
//using CakeShop.Core;
//using CakeShop.Core.Models;
//using System.Security.Claims;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace CakeShop.Controllers
//{
//    [Route("api/OrderCake")]
//    public class APIController : Controller
//    {
//        private readonly ICakeRepository _cakeRepository;
//        private readonly IShoppingCartService _shoppingCart;

//        // GET: api/<controller>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }
//        [HttpGet("AddToCart/{cakeId}")]
//        async public Task<string> Get(int cakeId)
//        {
//            var selectedCake = await _cakeRepository.GetCakeById(cakeId);
//            if (selectedCake == null)
//            {
//                return "Cake not Found";
//            }

//            await _shoppingCart.AddToCartAsync(selectedCake);

//            return "Cake Added";
//        }

//        // GET api/Ordercake/
//        [HttpGet("{firstname}/{lastname}/{notes}/{addressline1}/" +
//            "{addressline2}/{city}/{state}/{country}/{zipcode}/" +
//            "{phonenumber}/{email}/CakeID")]
//        public string Get(string firstname, string lastname, string notes,
//            string addressline1, string addressline2,
//            string city, string state, string country, 
//            string zipcode, string phonenumber, string email)
//        {
//            Order ApiOrder = new Order();
//            ApiOrder.FirstName = firstname;
//            ApiOrder.LastName = lastname;
//            ApiOrder.Notes = notes;
//            ApiOrder.AddressLine1 = addressline1;
//            ApiOrder.AddressLine2 = addressline2;
//            ApiOrder.City = city;
//            ApiOrder.State = state;
//            ApiOrder.Country = country;
//            ApiOrder.ZipCode = zipcode;
//            ApiOrder.PhoneNumber = phonenumber;
//            ApiOrder.Email = email;
//            ApiOrder.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            ApiOrder.Id = 22; //If I have time I will find a way to get a real order id
//            ApiOrder.OrderTotal = 50; //Again, if I have time I will make this a real value

//            return "Failed";

//        }

//        // POST api/<controller>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<controller>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
