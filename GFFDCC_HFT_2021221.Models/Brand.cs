using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Models
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }
        public Brand()
        {
            Cars = new HashSet<Car>();
        }
        public override string ToString()
        {
            return $" {this.Id,3} {this.Name,20}";
        }
    }
}
