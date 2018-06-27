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
    /// This entity stands for the Orders in our system
    /// </summary>
    [Table("Orders")]
    public class Orders : BaseEntity<int>
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
        /// gets/sets the date the order was created
        /// </summary>
        [Required]
        [Column("Orderdate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// gets/sets the date the order is being processed
        /// </summary>
        [Required]
        [Column("ProcessDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProcessDate { get; set; }

        /// <summary>
        /// gets/sets the date the order is send
        /// </summary>
        [Required]
        [Column("SendDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Gets/sets the courier id of the order
        /// </summary>
        [Column("Courier_Id")]
        public int? CouriersId { get; set; }

        /// <summary>
        /// Gets/sets the navigation property of the courier
        /// </summary>
        [ForeignKey("CouriersId")]
        public virtual Couriers CourierId { get; set; }

        /// <summary>
        /// gets/sets the client id of the order
        /// </summary>
        [Column("Client_Id")]
        public Guid? ClientsId { get; set; }

        /// <summary>
        /// gets/sets the navigation property of the client
        /// </summary>
        [ForeignKey("ClientsId")]
        public virtual Clients ClientId { get; set; }

        /// <summary>
        /// gets/sets the status id of the order
        /// </summary>
        [Column("Status_Id")]
        public int? StatusId { get; set; }

        /// <summary>
        /// gets/sets the navigation property of the status
        /// </summary>
        [ForeignKey("StatusId")]
        public virtual Status StatisId { get; set; }

        /// <summary>
        /// Gets/sets the products connected to this order
        /// </summary>
        public virtual ICollection<Orderline> Orderlines { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public Orders()
        {
        }
    }
}
