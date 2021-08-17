using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Quitanda.Models
{
    public class Senha
    {
        public int PasswordId { get; set; }
        public string Password { get; set; }
        public string ConfirmarPassword { get; set; }

        public List<Senha> ListarSenha()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Senha.json");
            var json = File.ReadAllText(caminhoArquivo);

            var listaSenhas = JsonConvert.DeserializeObject<List<Senha>>(json);

            return listaSenhas;
        }

        public bool reescreverArquivo(List<Senha> listaSenhas)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Senha.json");

            var json = JsonConvert.SerializeObject(listaSenhas, Formatting.Indented);

            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Senha Inserir(Senha senha)
        {
            var listaSenhas = this.ListarSenha();
            var maxId = listaSenhas.Max(s => s.PasswordId);
            senha.PasswordId = maxId + 1;
            listaSenhas.Add(senha);

            reescreverArquivo(listaSenhas);

            return senha;
        }

        public Senha Atualizar(int id, Senha senha)
        {
            var listaSenhas = this.ListarSenha();
            var itemIndex = listaSenhas.FindIndex(p =>  p.PasswordId == senha.PasswordId);

            if (itemIndex >= 0)
            {
                senha.PasswordId = id;
                listaSenhas[itemIndex] = senha;
            }
            else
            {
                return null;
            }
            reescreverArquivo(listaSenhas);
            return senha;

        }

        public bool Deletar(int id)
        {
            var listasenhas = this.ListarSenha();
            var itemIndex = listasenhas.FindIndex(p => p.PasswordId == id);

            if (itemIndex >= 0)
            {
                listasenhas.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            reescreverArquivo(listasenhas);
            return true;
        }
    }
}