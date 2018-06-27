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
    /// An entity class of our products
    /// </summary>
    [Table("Products")]
    public class Product : BaseEntity<int>
    {
        /// <summary>
        /// Checks if the product is new
        /// </summary>
        public override bool IsNew()
        {
            return this.Id == 0;
        }

        /// <summary>
        /// Overrides the id of the abstract class
        /// </summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        /// <summary>
        /// Gets/Sets the name of the product
        /// </summary>
        [Column("name")]
        [StringLength(255, ErrorMessage = "The name can maximum have 255 characters.")]
        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the description of the product
        /// </summary>
        [Column("descr")]
        public string Description { get; set; }

        /// <summary>
        /// Gets/sets the unit price of the product
        /// </summary>
        [Column("unit_price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0.00, 999999999, ErrorMessage = "Price must be greater than 0,00")]
        [DisplayName("Unit price (€)")]
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets/sets the currect stock of the product
        /// </summary>
        [Column("Currentstock")]
        public int CurrentStock { get; set; }

        /// <summary>
        /// Gets/sets the activation state of the product
        /// </summary>
        [Column("is_active")]
        [DisplayName("Is active?")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets/sets the Brand Id of the product
        /// </summary>
        [Column("Brand_Id")]
        public int? BrandsId { get; set; }

        /// <summary>
        /// Gets/sets the navigation property of the brand
        /// </summary>
        [ForeignKey("BrandsId")]
        public virtual Brands BrandId { get; set; }

        /// <summary>
        /// Gets/sets the Supplier Id of the product
        /// </summary>
        [Column("Supplier_Id")]
        public int? SuppliersId { get; set; }

        /// <summary>
        /// Gets/sets the navigation property of the supplier
        /// </summary>
        [ForeignKey("SuppliersId")]
        public virtual Suppliers SupplierId { get; set; }

        /// <summary>
        /// Gets/sets the Category Id of the product
        /// </summary>
        [Column("Category_Id")]
        public int? CategoriesId { get; set; }

        /// <summary>
        /// Gets/sets the navigation property of the category
        /// </summary>
        [ForeignKey("CategoriesId")]
        public virtual Categories CategoryId { get; set; }


        /// <summary>
        /// Gets/sets the categories the product is connected with
        /// </summary>
        public virtual ICollection<Categories> Categories { get; set; }

        /// <summary>
        /// gets/sets the orders the product is connected to
        /// </summary>
        public virtual ICollection<Orders> Orders { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Product()
        {
            Categories = new List<Categories>();
            Orders = new List<Orders>();
        }
    }
}
