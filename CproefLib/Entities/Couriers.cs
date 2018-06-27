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
    /// This entity stands for the Couriers in our system
    /// </summary>
    [Table("Couriers")]
    public class Couriers : BaseEntity<int>
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
        /// the email address of the courier
        /// </summary>
        [Required]
        [Column("email")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        /// <summary>
        /// the phone number of the courier
        /// </summary>
        [Required]
        [Column("phonenr")]
        [Phone]
        public string Phonenr { get; set; }

        /// <summary>
        /// Gets/Sets the name of the courier
        /// </summary>
        [Column("name")]
        [StringLength(50, ErrorMessage = "The name can maximum have 50 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the orders the courier is connected to
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
