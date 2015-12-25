using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Portal.Dominio
{
    public class Palestra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PalestraId { get; set; }

        public int Id { get; set; }
        public string Tema { get; set; }
        public string Instituicao { get; set; }
        
        [Display(Name = "Data da Palestra")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:M}")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime Dia { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time, ErrorMessage="Horário inválido")] 
        public DateTime Horario { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        
       
    }
}
