using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamP1.Models
{
    public class Recuerdo
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TituloRecuerdo { get; set; }
        [Required]
        public string TipoRecuerdo { get; set; }
        [Required]
        public int Claridad { get; set; }
        [Required]
        public int SintezoideId { get; set; }

        public Sintezoide sintezoide { get; set; }

    }
}