using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public virtual Brand Brand { get; set; }
        [NotMapped]
        public virtual CarDealership CarDealership { get; set; }

        public int BrandId { get; set; }
        public int CarDealershipID { get; set; }
    }
}
