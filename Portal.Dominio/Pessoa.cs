using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Portal.Dominio
{
    public class Pessoa
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PessoaId { get; set; }

        public int PalestraId { get; set; }

        [Required(ErrorMessage = "Digite seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite seu endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Digite seu bairro")]
        public string Bairro { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Digite o dia do seu aniversário")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Digite o nome da sua mãe")]
        [Display(Name = "Nome da Mãe")]
        public string Mae { get; set; }

        public string Pai { get; set; }

        [Required(ErrorMessage = "Digite seu telefone fixo ou celular")]
        public string Fone { get; set; }

        [Required(ErrorMessage = "Digite um e-mail válido")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O email informado não é valido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Colegio { get; set; }

        [Required(ErrorMessage = "Digite seu RG")]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        public virtual ICollection<Palestra> Palestras { get; set; }
        
        
    }
}