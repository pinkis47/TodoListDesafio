using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListDesafio.Models;

namespace TodoListDesafio.ViewComponents
{
    public class ListaTarefasViewComponent : ViewComponent
    {
        private readonly Context _context;

        public ListaTarefasViewComponent(Context context) {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string data) {

            return View(await _context.Tarefa.OrderBy(t => t.Horario).Where(t => t.Data == data).ToListAsync());
                }
    }
}
