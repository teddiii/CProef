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
    /// This entity stands for the different order status in our system
    /// </summary>
    [Table("Status")]
    public class Status : BaseEntity<int>
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
        /// Gets/sets the description of the status
        /// </summary>
        [Required]
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets/sets the orders the status is connected to
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
