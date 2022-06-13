using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProfSystem.Models
{
    public class Professional
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }

        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Phone(ErrorMessage = "Insira um valor válido")]
        public string Phone { get; set; }

        [DisplayName("RG")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Rg { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Address { get; set; }

        [DisplayName("Salário (em reais)")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Wage { get; set; }

        [DisplayName("Salário calculado com horas extras")]
        public decimal WageWithOvertime { get; set; }

        [DisplayName("Horas extras trabalhadas")]
        public int Hour { get; set; }
    }
}