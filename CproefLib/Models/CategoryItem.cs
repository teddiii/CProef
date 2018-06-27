using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.Models
{
    /// <summary>
    /// Overview item for categories when displayed in a combobox (dropdownlist)
    /// </summary>
    public class CategoryItem
    {
        /// <summary>
        /// The ID of the category
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// The display name
        /// </summary>
        public string Name { get; set; }
    }
}
