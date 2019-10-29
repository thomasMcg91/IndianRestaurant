using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndianRestaurant.Models.ViewModels
{
    public class IndexViewModel
    {
        //view model for landing page, adding all requried attributes 
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Coupon> Coupons { get; set; }

    }
}
