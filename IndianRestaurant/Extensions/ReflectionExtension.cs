using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndianRestaurant.Extensions
{
    public static class ReflectionExtension
    {
        //method to return an ienumerable of selectlist item to drop down, extending the IEnumerable class 
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}
