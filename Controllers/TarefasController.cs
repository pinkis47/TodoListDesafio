using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListDesafio.Models;

namespace TodoListDesafio.Controllers
{
    public class TarefasController : Controller
    {
        private readonly Context _context;

        public TarefasController(Context context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(PegaDatas());
        }

        private List<DatasVM> PegaDatas() {
            DateTime dataAtual = DateTime.Now;
            DateTime dataLimite = DateTime.Now.AddDays(10);
            DatasVM datas;
            List<DatasVM> listaDatas = new List<DatasVM>();

            for (int i = 0; i < 10; i++)
            {
                datas = new DatasVM();
                datas.Data = dataAtual.AddDays(i).ToShortDateString();

                datas.identifica = "collapse " + dataAtual.ToShortDateString().Replace("/", "");
                listaDatas.Add(datas);

            }
            return listaDatas;
        }
        [HttpGet]
        public IActionResult RegistraTarefa(string dataTarefa) {
            Tarefas tarefas = new Tarefas
            {
                Data = dataTarefa
            };
            return View(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> RegistraTarefa(Tarefas tarefas) {
            if (ModelState.IsValid)
            {
                _context.Tarefa.Add(tarefas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefas);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AtualizaTarefa(int Tarefa_id)
        {
            Tarefas tarefas = await _context.Tarefa.FindAsync(Tarefa_id);

            if (tarefas == null)

                return NotFound();
            return View(tarefas);

        }

        [HttpPost]
        public async Task<IActionResult> AtualizaTarefa(Tarefas tarefas) {
            if (ModelState.IsValid)
            {
                _context.Update(tarefas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(tarefas);
        }

        [HttpPost]
        public async Task<JsonResult> ExcluirTarefa(int Tarefa_id) {
            Tarefas tarefas = await _context.Tarefa.FindAsync(Tarefa_id);
            _context.Tarefa.Remove(tarefas);
            await _context.SaveChangesAsync();
            return Json(true);
        }
    }
}
