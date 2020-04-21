using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Pizza_App_FGD
{
    public class Pizza
    {
        public string gsName { get; set; }
        public string gsIngredient1 { get; set; }
        public string gsIngredient2 { get; set; }
        public string gsIngredient3 { get; set; }
        public string gsIngredient4 { get; set; }
        public string gsIngredient5 { get; set; }

        public Pizza(string name)
        {
            gsName = name;
        }
    }
}