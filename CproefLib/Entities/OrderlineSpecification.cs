using System.ComponentModel.DataAnnotations.Schema;

namespace CproefLib.Entities
{
    public class OrderlineSpecification : BaseEntity<int>
    {
        public override int Id { get; set; }

        public override bool IsNew()
        {
            return Id == 0;
        }

        public int? OrderlineId { get; set; }

        [ForeignKey("OrderlineId")]
        public virtual Orderline Orderline { get; set; }

        public string Description { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Description, Value);
        }
    }
}