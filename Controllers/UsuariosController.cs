using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        
        public IActionResult listaDeUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.AdminVerify(this);

            return View(new UsuarioService().Listagem());
        }        

        public IActionResult editarUsuario(int id) {
            return View(new UsuarioService().FindbyId(id));    
        }

        [HttpPost]
        public IActionResult editarUsuario(Usuario usuarioEdicao) {
            UsuarioService us = new UsuarioService();
            us.editarUsuario(usuarioEdicao);
            return RedirectToAction("listaDeUsuarios","Usuarios");
        }

        public IActionResult registrarUsuarios() {
            Autenticacao.CheckLogin(this);
            Autenticacao.AdminVerify(this);
            return View();            
        }

        [HttpPost]
        public IActionResult registrarUsuarios(Usuario novoUser)
        {
           
            Autenticacao.CheckLogin(this);
            Autenticacao.AdminVerify(this);

            UsuarioService us = new UsuarioService();
            
            if (!string.IsNullOrEmpty(novoUser.Nome) && !string.IsNullOrEmpty(novoUser.Senha) && !string.IsNullOrEmpty(novoUser.Login) ) {

               novoUser.Senha = Crypto.Generate(novoUser.Senha);
               us.Inserir(novoUser);
               return RedirectToAction("cadastroRealizado");

            }

            else{ 
                ViewData["Error"] ="Por favor informe dados válidos";
                return View();
            }

           
        }        

   public IActionResult Excluir(int id)
 {
       Autenticacao.CheckLogin(this);
        Autenticacao.AdminVerify(this);
      UsuarioService us = new UsuarioService();
       Usuario u = us.FindbyId(id);

    return View(u);
  }

  [HttpPost]
  public IActionResult Excluir(Usuario u, int id, string decisao)
  {
       
      UsuarioService us = new UsuarioService();

      if( decisao == "s")
     {
      us.Deletar(u); 
      }

      return RedirectToAction("listaDeUsuarios");
  }
            

    
        public IActionResult cadastroRealizado()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.AdminVerify(this);

            return View();
        }

        public IActionResult NeedAdmin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }


        public IActionResult sair(){
           HttpContext.Session.Clear();
           return RedirectToAction("Index","Home"); 
        }

    }
}