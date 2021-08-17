using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Quitanda.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmarPassword { get; set; }

        public List<Usuario> ListarUsuario()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Usuario.json");
            var json = File.ReadAllText(caminhoArquivo);

            var listaSenhas = JsonConvert.DeserializeObject<List<Usuario>>(json);

            return listaSenhas;
        }

        public bool reescreverArquivo(List<Usuario> ListaUsuario)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Usuario.json");

            var json = JsonConvert.SerializeObject(ListaUsuario, Formatting.Indented);

            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Usuario Inserir(Usuario usuario)
        {
            var listasUsuario = this.ListarUsuario();
            var maxId = listasUsuario.Max(s => s.UsuarioId);
            usuario.UsuarioId = maxId + 1;
            listasUsuario.Add(usuario);

            reescreverArquivo(listasUsuario);

            return usuario;
        }

        public Usuario Atualizar(int id, Usuario usuario)
        {
            var listasUsuario = this.ListarUsuario();
            var itemIndex = listasUsuario.FindIndex(p => p.UsuarioId == usuario.UsuarioId);

            if (itemIndex >= 0)
            {
                usuario.UsuarioId = id;
                listasUsuario[itemIndex] = usuario;
            }
            else
            {
                return null;
            }
            reescreverArquivo(listasUsuario);
            return usuario;

        }

        public bool Deletar(int id)
        {
            var listasUsuarios = this.ListarUsuario();
            var itemIndex = listasUsuarios.FindIndex(p => p.UsuarioId == id);

            if (itemIndex >= 0)
            {
                listasUsuarios.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            reescreverArquivo(listasUsuarios);
            return true;
        }
    }
}