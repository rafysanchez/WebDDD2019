using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.Interface;
using Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDDD2019.Controllers
{
    public class ProdutoWebController : Controller
    {

        private readonly InterfaceAppProduto AppProduto;


        public ProdutoWebController(InterfaceAppProduto _AppProduto)
        {
            AppProduto = _AppProduto;
        }


        // GET: ProdutoWeb
        public ActionResult Index()
        {
            //return View(AppProduto.Listar());
            return View(AppProduto.List());
        }

        // GET: ProdutoWeb/Details/5
        public ActionResult Details(int id)
        {
            //return View(AppProduto.ObterPorId(id));
            return View(AppProduto.GetEntity(id));
        }

        // GET: ProdutoWeb/Create
        public ActionResult Create()
        {
            return View(new Produto());
        }

        // POST: ProdutoWeb/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto collection)
        {
            try
            {
                // TODO: Add insert logic here
                //AppProduto.Adcionar(collection);
                // AppProduto.Add(collection);

                collection = AppProduto.AdicionarVerificarExisteNome(collection);

                if (collection.notificacoes.Any())
                {
                    foreach (var item in collection.notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.mensagem);
                    }
                }

                return View(collection);

                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoWeb/Edit/5
        public ActionResult Edit(int id)
        {
            // return View(AppProduto.ObterPorId(id));
            return View(AppProduto.GetEntity(id));
        }

        // POST: ProdutoWeb/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Produto collection)
        {
            try
            {
                // TODO: Add update logic here

                //AppProduto.Atualizar(collection);
                AppProduto.Update(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdutoWeb/Delete/5
        public ActionResult Delete(int id)
        {
            //return View(AppProduto.ObterPorId(id));
            return View(AppProduto.GetEntity(id));
        }

        // POST: ProdutoWeb/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Produto collection)
        {
            try
            {
                //AppProduto.Excluir(collection);
                AppProduto.Delete(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}