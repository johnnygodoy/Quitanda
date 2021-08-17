using Quitanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quitanda.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Senha
        public IEnumerable<Usuario> Get()
        {
            Usuario usuario = new Usuario();

            return usuario.ListarUsuario();
        }

        // GET: api/Senha/5
        public Usuario Get(int id)
        {
            Usuario usuario = new Usuario();

            return usuario.ListarUsuario().Where(x => x.UsuarioId == id).FirstOrDefault();
        }

        // POST: api/Senha
        public List<Usuario> Post(Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            _usuario.Inserir(usuario);

            return _usuario.ListarUsuario();
        }

        // PUT: api/Senha/5
        public Usuario Put(int id, Usuario usuario)
        {
            Usuario _usuario = new Usuario();

            return _usuario.Atualizar(id, usuario);
        }

        // DELETE: api/Senha/5
        public void Delete(int id)
        {
            Usuario _usuario = new Usuario();

            _usuario.Deletar(id);
        }
    }
}
