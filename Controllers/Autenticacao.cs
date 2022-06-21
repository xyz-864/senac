using Biblioteca.Models;


using System.Linq;
using System.Collections.Generic;
using System.Collections;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Web;




namespace Biblioteca.Controllers
{
    public class Autenticacao : Controller
    {
        public static void CheckLogin(Controller controller)
        {   
            if(string.IsNullOrEmpty(controller.HttpContext.Session.GetString("login")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }
    
    
         public static bool verify(string login, string senha, Controller controller){
            using(BibliotecaContext bc = new BibliotecaContext()){

               AdminExists(bc);

         senha = Crypto.Generate(senha);
         

               IQueryable<Usuario> Found = bc.Usuarios.Where(u => u.Login == login && u.Senha == senha);
               List<Usuario> FoundList = Found.ToList();

              if (FoundList.Count == 0){
            return false;
        } else {
             
             controller.HttpContext.Session.SetString("login",FoundList[0].Login);
              controller.HttpContext.Session.SetString("nome",FoundList[0].Nome);
               controller.HttpContext.Session.SetInt32("tipo",FoundList[0].Priority);
             return true;

        }
            
            }
         }

    public static void AdminExists(BibliotecaContext bc){

      IQueryable<Usuario> Found = bc.Usuarios.Where(u => u.Login == "admin");

if (Found.ToList().Count==0){

Usuario admin = new Usuario();
admin.Nome = "Admin";
admin.Login = "admin";
admin.Priority = Usuario.ADMIN;
admin.Senha = Crypto.Generate("123");

bc.Usuarios.Add(admin);
bc.SaveChanges();

}
    }

public static void AdminVerify(Controller controller) {
    if (!(controller.HttpContext.Session.GetInt32("tipo") == 1)){
        controller.Request.HttpContext.Response.Redirect("/Usuarios/NeedAdmin");
    }
}


}

}

