using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListDesafio.Models
{
    public class Tarefas
    {
        [Key]
        public int Tarefa_id { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigadório!")]
        [StringLength(50, ErrorMessage = "Você ultrapassou o limite de 50 caracteres")]
        public string Nome { get; set; }
        
        public string Data { get; set; }
        
        [Required(ErrorMessage = "{0} é obrigadório!")]
        [DataType(DataType.Time)]
        public string Horario { get; set; }

        [Required(ErrorMessage = "{0} é obrigadório!")]
        public string Status { get; set; }
    }
}
