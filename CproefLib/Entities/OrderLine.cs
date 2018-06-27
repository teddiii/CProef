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
    /// This entity stands for the ordered products
    /// </summary>
    [Table("Orderlines")]
    public class Orderline : BaseEntity<int>
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
        [Column("OrderlineId", Order = 0)]
        public override int Id { get; set; }

        [Key]
        [Column("ProductId", Order = 1)]
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Key]
        [Column("OrderId", Order = 2)]
        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Orders Order { get; set; }

        [Required]
        [Column("Amount")]
        public int Amount { get; set; }
        
        public virtual ICollection<OrderlineSpecification> Specifications { get; set; }
    }
}
