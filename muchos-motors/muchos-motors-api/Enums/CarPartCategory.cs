using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Enums
{
    public enum CarPartCategory
    {
        [Display(Name = "Motor")]
        Engine,

        [Display(Name = "Prijenos")]
        Transmission,

        [Display(Name = "Ovjes")]
        Suspension,

        [Display(Name = "Sistem kočenja")]
        BrakeSystem,

        [Display(Name = "Ispušni sistem")]
        ExhaustSystem,

        [Display(Name = "Enterijer")]
        Interior,

        [Display(Name = "Eksterijer")]
        Exterior,

        [Display(Name = "Elektronika")]
        Electrical,

        [Display(Name = "Ostalo")]
        Other
    }
}

