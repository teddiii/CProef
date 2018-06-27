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
    /// This entity stands for the Clients of our system
    /// </summary>
    [Table("Clients")]
    public class Clients : BaseEntity<Guid>
    {
        /// <summary>
        /// This checks if the model is new
        /// </summary>
        public override bool IsNew()
        {
            return Id == Guid.Empty;
        }


        /// <summary>
        /// overrides the id of the base entity
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override Guid Id { get; set; }

        /// <summary>
        /// last name of the client
        /// </summary>
        [Required]
        [Column("last name")]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        /// <summary>
        /// first name of the client
        /// </summary>
        [Required]
        [Column("first name")]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        /// <summary>
        /// returns the full name of the client
        /// </summary>
        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        /// <summary>
        /// the is the unique user name of the client
        /// </summary>
        [Column("user_name")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        [Display(Name = "User name")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

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
        /// This holds the encrypted password
        /// </summary>
        [Required]
        [Column("encrypted_pwd")]
        [StringLength(255)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// the salt key for the encryption of the password
        /// </summary>
        [Column("pwd_salt")]
        [StringLength(255)]
        public string Salt { get; set; }

        /// <summary>
        /// Gets/sets the orders the client is connected to
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
