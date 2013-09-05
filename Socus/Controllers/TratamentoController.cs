using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Socus.Forms;
using Felice.Mvc;
using Socus.Repositories;
using Socus.Entities;
using Felice.Core;

namespace Socus.Controllers
{
    public class TratamentoController : Controller
    {
        private TratamentoRepositorio tratamentoRepositorio;

        public TratamentoController()
        {
            this.tratamentoRepositorio = new TratamentoRepositorio(); 
        }

        public ActionResult Index()
        {
            var tratamentos = this.tratamentoRepositorio.All();
            return View(tratamentos);
        }

        public ActionResult Novo()
        {
            return View("Editar", new NovoTratamentoForm());
        }

        public ActionResult Alterar(int id)
        {
            var tratamento = this.tratamentoRepositorio.ById(id);

            return View("Editar", new NovoTratamentoForm()
            {
                Id = tratamento.Id,
                Nome = tratamento.Nome,
                Preco = tratamento.Preco.ToString()
            });
        }

        [HttpPost]
        public ActionResult Apagar(int id)
        {
            return this.Handle(id)
                .With(x => this.tratamentoRepositorio.DeleteById(id))
                .OnFailure(x => RedirectToAction("Index"))
                .OnSuccess(x => RedirectToAction("Index"), "Tratamento apagado com sucesso");
        }

        [HttpPost]
        public ActionResult Salvar(NovoTratamentoForm form)
        {
            return this.Handle(form)
                .With(x => 
                {
                    this.tratamentoRepositorio.Save(new Tratamento
                    {
                        Id = form.Id,
                        Nome = form.Nome,
                        Preco = form.Preco.ToDecimal2()
                    });
                })
                .OnFailure(x => View("Editar", form))
                .OnSuccess(x => RedirectToAction("Index"), "Tratamento salvo com sucesso");
        }
    }
}
