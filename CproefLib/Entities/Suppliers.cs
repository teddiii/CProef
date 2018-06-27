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
    /// This entity stands for the different supliers in our system
    /// </summary>
    [Table("Suppliers")]
    public class Suppliers : BaseEntity<int>
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
        /// Gets/Sets the name of the supplier
        /// </summary>
        [Column("name")]
        [StringLength(50, ErrorMessage = "The name can maximum have 50 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// the email address of the user
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

        [Required]
        [Column("streetname_and_number")]
        public string StreetnameAndNumber { get; set; }

        [Required]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [Column("postalcode")]
        public int Postalcode { get; set; }

        /// <summary>
        /// Gets/sets the products the supplier is connected to
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
