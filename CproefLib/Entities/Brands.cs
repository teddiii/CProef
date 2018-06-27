using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.Entities
{
    /// <summary>
    /// This entity stands for the Brands in our system
    /// </summary>
    [Table("Brands")]
    public class Brands : BaseEntity<int>
    {
        /// <summary>
        /// Checks if the brand is new
        /// </summary>
        public override bool IsNew()
        {
            return this.Id == 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets/sets the name of the brand
        /// </summary>
        [Column("name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the products connected to this brand
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
