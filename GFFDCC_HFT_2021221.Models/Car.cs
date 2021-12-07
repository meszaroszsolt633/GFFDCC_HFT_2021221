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
    [Table("cars")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Model { get; set; }


        public int BasePrice { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual CarDealership CarDealership { get; set; }
        [ForeignKey("brands")]
        public int BrandId { get; set; }
        [ForeignKey("cardealerships")]
        public int CarDealershipID { get; set; }
        public override string ToString()
        {
            if (this.Id != null) {
                return $" {this.Id,3}{this.Model,20} {this.BasePrice + "$",8} {this.BrandId,6} {this.CarDealership.Id,11}";
            }
            return "";
        }
        public override bool Equals(object obj)
        {
            if(obj is Car)
            {
                Car other = obj as Car;

                return this.Id == other.Id &&
                    this.Model == other.Model &&
                    this.BasePrice == other.BasePrice &&
                    this.BrandId == other.BrandId &&
                    this.CarDealershipID == other.CarDealershipID;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
