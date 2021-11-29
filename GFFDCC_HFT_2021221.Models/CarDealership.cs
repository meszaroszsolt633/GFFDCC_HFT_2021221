using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Models
{
    [Table("cardealerships")]
    public class CarDealership
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Taxnumber { get; set; }
        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }
        public CarDealership()
        {
            Cars = new HashSet<Car>();
        }
    }
}
