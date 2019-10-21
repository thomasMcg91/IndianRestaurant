using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndianRestaurant.Models
{
    public class MenuItem
    {

        //need to alter casace to noaction in migration that if a category or sub is deleted, it will not delete the menuitem table
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }

        public enum ESpicy { NA = 0, NotSpicy = 1, Spicy = 2, VerySpicy = 3 }

        public string Image { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { set; get; }


        [Display(Name = "SubCategory")]
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { set; get; }

        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than ${1}")]
        public double Price { get; set; }

    }
}
