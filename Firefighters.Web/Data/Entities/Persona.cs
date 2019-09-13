using System;
using System.ComponentModel.DataAnnotations;

namespace Firefighters.Web.Data.Entities
{
    public class Persona
    {
        public int PersonaID { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Apellido { get; set; }
                
        public string FullName => $"{Nombre} {Apellido}";

        [Display(Name = "DNI")]
        [MaxLength(10, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string DNI { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? NacimientoFecha { get; set; }

        [Display(Name = "Lugar Nacimiento")]
        [MaxLength(100, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string LugarNacimiento { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string Direccion { get; set; }


        public int? LocalidadID { get; set; }

        [Display(Name = "Tel. Particular")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string TelParticular { get; set; }

        [Display(Name = "Tel. Celular")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string TelCelular { get; set; }

        [Display(Name = "Grupo Sanguineo")]
        public string GrupoSanguineo { get; set; }

        [Display(Name = "Factor Sanguineo")]
        public string FactorSanguineo { get; set; }

        public Int16 ?ObraSocialID { get; set; }

        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? IngresoFecha { get; set; }

        [Display(Name = "Carácter")]
        public string Caracter { get; set; }

        [Display(Name = "Res Jefatura")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string ResJefatura { get; set; }

        [Display(Name = "Acta Comisión")]
        [MaxLength(20, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string ActaComision { get; set; }

        public Int16 ?LugarTrabajoID { get; set; }

        public Int16 ?ProfesionID { get; set; }

        [Display(Name = "Tel. Trabajo")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string TelTrabajo { get; set; }
    }
}
