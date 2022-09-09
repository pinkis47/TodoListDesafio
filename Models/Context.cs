using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListDesafio.Models
{
    public class Context : DbContext
    {
        public DbSet<Tarefas> Tarefa { get; set; }


        public Context(DbContextOptions<Context> opcoes) : base(opcoes) { 
        }
    }
}
