using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndianRestaurant.Models.ViewModels
{
    //ViewModels are a combination of more than one model for a specific view, as the view
    //will require multiple models passed to it 
    public class SubCategoryAndCategoryViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<string> SubCategoryList { get; set; }
        public string StatusMessage { get; set; }

    }
}
