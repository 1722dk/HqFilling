using System;
using System.ComponentModel.DataAnnotations;

namespace HqFilling.Model
{
    public class MachineModel : BaseModel
    {
        public int MachineId { get; set; } 

        [Required]
        [Display(Name = "Machine Name")]
        public string MachineName { get; set; }

        [Required]
        [Display(Name = "Machine Code")]
        public string MachineCode { get; set; }  

        [Required]
        [Display(Name = "Machine Volume")]
        public double MachineVolume { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public int FuelTypeId { get; set; }

        public string Comment { get; set; }   

    }
}
