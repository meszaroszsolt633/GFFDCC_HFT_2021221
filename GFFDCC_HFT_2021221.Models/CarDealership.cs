using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Models
{
    [Table("cardealerships")]
    public class CarDealership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string Taxnumber { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Carsatstock { get; set; }
        public CarDealership()
        {
            Carsatstock = new HashSet<Car>();
        }
        public override string ToString()
        {
            return $" {this.Id,3} {this.Name,20} {this.Country,12} {this.Taxnumber,12}";
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
