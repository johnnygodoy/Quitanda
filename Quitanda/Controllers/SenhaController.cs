using Quitanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quitanda.Controllers
{
    public class SenhaController : ApiController
    {
     
        // GET: api/Senha
        public IEnumerable<Senha> Get()
        {
            Senha senha = new Senha();

            return senha.ListarSenha();
        }

        // GET: api/Senha/5
        public Senha Get(int id)
        {
            Senha senha = new Senha();

            return senha.ListarSenha().Where(x => x.PasswordId == id).FirstOrDefault();
        }

        // POST: api/Senha
        public List<Senha> Post(Senha senha)
        {
            Senha _senha = new Senha();

            _senha.Inserir(senha);

            return _senha.ListarSenha();
        }

        // PUT: api/Senha/5
        public Senha Put(int id, Senha senha)
        {
            Senha _senha = new Senha();

            return _senha.Atualizar(id, senha);
        }

        // DELETE: api/Senha/5
        public void Delete(int id)
        {
            Senha _senha = new Senha();

            _senha.Deletar(id);
        }
    }
}
