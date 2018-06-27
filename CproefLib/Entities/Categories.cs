using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.Entities
{
    /// <summary>
    /// This entity stands for the productcategories of our system
    /// </summary>
    [Table("Categories")]
    public class Categories : BaseEntity<int>
    {
        /// <summary>
        /// Checks if the category is new
        /// </summary>
        public override bool IsNew()
        {
            return this.Id == 0;
        }

        /// <summary>
        /// Overrides the id of the base entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets/Sets the name of the product category
        /// </summary>
        [Column("name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the activation state of the product
        /// </summary>
        [Column("is_active")]
        [DisplayName("Is active?")]
        public bool IsActive { get; set; }

        /// <summary>
        /// This is the optional parent id of our category
        /// </summary>
        [Column("parent_id")]
        public int? ParentId { get; set; }

        /// <summary>
        /// This is a navigation property of the parent of our category
        /// </summary>
        [ForeignKey("ParentId")]
        public virtual Categories Parent { get; set; }

        /// <summary>
        /// Gets/sets the collection of subcategories of our category
        /// </summary>
        public virtual ICollection<Categories> Children { get; set; }

        /// <summary>
        /// Gets/sets the products connected to this category
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Gets/sets the default specs the category is connected to
        /// </summary>
        public virtual ICollection<DefaultSpecs> DefaultSpecs { get; set; }
    }
}
