using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Quitanda.Models
{

    public class Fruta
    {
        public int FrutaID { get; set; }
        public string NomeFruta { get; set; }
        public List<Fruta> ListarFruta()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(caminhoArquivo);

            var listaFrutas = JsonConvert.DeserializeObject<List<Fruta>>(json);

            return listaFrutas;
        }

        public bool reescreverArquivo(List<Fruta> listaFrutas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaFrutas, Formatting.Indented);

            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Fruta Inserir(Fruta fruta)
        {
            var listaFrutas = this.ListarFruta();
            var maxId = listaFrutas.Max(f => f.FrutaID);
            fruta.FrutaID = maxId + 1;
            listaFrutas.Add(fruta);

            reescreverArquivo(listaFrutas);

            return fruta;
        }

        public Fruta Atualizar(int id, Fruta Fruta)
        {
            var listafrutas = this.ListarFruta();
            var itemIndex = listafrutas.FindIndex(f => f.FrutaID == Fruta.FrutaID);

            if (itemIndex >= 0)
            {
                Fruta.FrutaID = id;
                listafrutas[itemIndex] = Fruta;
            }
            else
            {
                return null;
            }
            reescreverArquivo(listafrutas);
            return Fruta;

        }

        public Fruta GetFruta(int id)
        {
            Fruta frutas = new Fruta();
            var idFruta = frutas.ListarFruta().Where(x => x.FrutaID == id).FirstOrDefault();
            return (idFruta);
        }

        public bool Deletar(int id)
        {
            var listaFrutas = this.ListarFruta();
            var itemIndex = listaFrutas.FindIndex(f => f.FrutaID == id);

            if (itemIndex >= 0)
            {
                listaFrutas.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            reescreverArquivo(listaFrutas);
            return true;
        }
    }
}