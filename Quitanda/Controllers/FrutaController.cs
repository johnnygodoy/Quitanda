using Quitanda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quitanda.Controllers
{
    public class FrutaController : ApiController
    {
        // GET: api/Fruta
        public IEnumerable<Fruta> Get()
        {
            Fruta frutas = new Fruta();

            return frutas.ListarFruta();
        }


        // GET: api/Fruta/5
        public Fruta Get(int id)
        {
            Fruta frutas = new Fruta();

            return frutas.ListarFruta().Where(x => x.FrutaID == id).FirstOrDefault();
        }


        // POST: api/Fruta
        public List<Fruta> Post(Fruta fruta)
        {
            Fruta _fruta = new Fruta();

            _fruta.Inserir(fruta);

            return _fruta.ListarFruta();
        }
        // PUT: api/Fruta/5
        public Fruta Put(int id, [FromBody] Fruta fruta)
        {
            Fruta _fruta = new Fruta();

            return _fruta.Atualizar(id, fruta);

        }

        // DELETE: api/Fruta/5
        public void Delete(int id)
        {
            Fruta _fruta = new Fruta();

            _fruta.Deletar(id);
        }
    }
}
