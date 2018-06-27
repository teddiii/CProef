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
    /// This is the generic base entity for 
    /// all our entities in the database
    /// </summary>
    public abstract class BaseEntity<ID>
    {
        /// <summary>
        /// Gets/sets the unique Id of our entity
        /// </summary>
        public abstract ID Id { get; set; }

        /// <summary>
        /// Gets/sets the moment when the entity is created
        /// </summary>
        [Column("created_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets/sets the moment when the entity is modified
        /// </summary>
        [Column("modified_at")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Gets/sets the moment when the entity is deleted
        /// </summary>
        [Column("deleted_at")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeletedAt { get; set; }

        /// <summary>
        /// Checks if the object is new
        /// </summary>
        public abstract bool IsNew();

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseEntity()
        {
            CreatedAt = ModifiedAt = DateTime.Now;
        }
    }
}
