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
    /// This entity stands for the default specifications in our system
    /// </summary>
    [Table("DefaultSpecs")]
    public class DefaultSpecs : BaseEntity<int>
    {
        /// <summary>
        /// This checks if the model is new
        /// </summary>
        public override bool IsNew()
        {
            return this.Id == 0;
        }

        /// <summary>
        /// overrides the id of the base entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }

        /// <summary>
        /// Gets/sets the description of the spec
        /// </summary>
        [Required]
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// gets/sets the value of the spec
        /// </summary>
        [Required]
        [Column("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets/sets the category id of the spec
        /// </summary>
        [Column("Categories_Id")]
        public int? CategoriesId { get; set; }

        /// <summary>
        /// Gets/sets the navigation property of the category
        /// </summary>
        [ForeignKey("CategoriesId")]
        public virtual Categories CategoryId { get; set; }
    }
}
