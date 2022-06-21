using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
     
  public List <Usuario> Listagem(){
     using(BibliotecaContext bc = new BibliotecaContext()){
       return bc.Usuarios.ToList();
     }
  }

 public Usuario FindbyId(int Id){
    using(BibliotecaContext bc = new BibliotecaContext()){
        return bc.Usuarios.Find(Id);
    }
 }

 public void Inserir(Usuario u){
     using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }

 public void Deletar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
               
                 bc.Usuarios.Remove(bc.Usuarios.Find(u.Id));
                 bc.SaveChanges();
            }
        }

   public void editarUsuario(Usuario userEditar){
            using(BibliotecaContext bc = new BibliotecaContext()){

               Usuario u = bc.Usuarios.Find(userEditar.Id);

               u.Login =  userEditar.Login;
               u.Nome =  userEditar.Nome;
               u.Senha = userEditar.Senha;
               u.Priority = userEditar.Priority;

               bc.SaveChanges();
            }    
        }
    }
}

 










