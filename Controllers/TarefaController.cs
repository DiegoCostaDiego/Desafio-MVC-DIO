using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Context;
using DesafioAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAPI.Controllers
{
    
    public class TarefaController : Controller
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult Detalhes(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
               return NotFound();

            return View(tarefa);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
            {
                ModelState.AddModelError("Data", "A data da tarefanão pode ser vazia");
                return View(tarefa);
            }

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

         return View(tarefa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);
            if (tarefaBanco == null)
                return NotFound();
            
            if (tarefa.Data == DateTime.MinValue)
            {
                ModelState.AddModelError("Data", "A data da tarefaa não pode ser vazia");
                return View(tarefa);
            }

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BuscarPorTitulo(string titulo)
        {
            var tarefas = _context.Tarefas
                .Where(t => t.Titulo.Contains(titulo))
                .ToList();

            return View(tarefas);
        }

        public IActionResult BuscarPorData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarPorData(DateTime data)
        {
            var tarefas = _context.Tarefas
            .Where(t => t.Data.Date == data.Date)
            .ToList();

            return View(tarefas);
        }

        public IActionResult BuscarPorStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefas
                .Where(t => t.Status == status)
                .ToList();

            return View(tarefas);
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
                return NotFound();

            return View(tarefa);    
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarConfirmado(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
               return NotFound();

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}