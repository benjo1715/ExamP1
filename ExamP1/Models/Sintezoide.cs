using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamP1.Models
{
    public class Sintezoide
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public int NivelIa { get; set; }
        [Required]
        public string FuenteEnergia { get; set; }

        public virtual ICollection<Recuerdo> Recuerdos { get; set; }
    }
}