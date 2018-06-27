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
    /// This entity stands for the Languages we use in our system
    /// </summary>
    [Table("Languages")]
    public class Languages : BaseEntity<int>
    {
        /// <summary>
        /// Checks if the language is new
        /// </summary>
        public override bool IsNew()
        {
            return this.Id == 0;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public override int Id { get; set; }


    }
}
