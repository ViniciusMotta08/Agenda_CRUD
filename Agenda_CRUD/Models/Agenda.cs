using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Agenda_CRUD.Models
{
    public class Agenda
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório!")]
        [DisplayName("Nome")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(14)")]
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório!")]
        [DisplayName("Telefone")]
        public string Telephone { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório!")]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
