using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Web;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.AdminVerify(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            LivroService livroService = new LivroService();

            if(l.Id == 0)
            {
                livroService.Inserir(l);
            }
            else
            {
                livroService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            Autenticacao.CheckLogin(this);
            FiltrosLivros objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }
            LivroService livroService = new LivroService();
            

            return View(livroService.ListarTodos(objFiltro));
            
        }


        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.AdminVerify(this);
            LivroService ls = new LivroService();
            Livro l = ls.ObterPorId(id);
            return View(l);
        }

                          
  public IActionResult Excluir(int id)
 {
        Autenticacao.CheckLogin(this);
        Autenticacao.AdminVerify(this);
      LivroService ls = new LivroService();
       Livro l = ls.ObterPorId(id);

    return View(l);
  }

  [HttpPost]
  public IActionResult Excluir(Livro l, int id, string decisao)
  {
       
      LivroService ls = new LivroService();

      if( decisao == "s")
     {
      ls.Deletar(l); 
      }

      return RedirectToAction("Listagem");
  }
                        

    }
}