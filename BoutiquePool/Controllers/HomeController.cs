using System.Diagnostics;
using BoutiquePool.DataDefinition;
using BoutiquePool.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BoutiquePool.Controllers
{
    //Declaracao da Classe de Controller 
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retorna uma lista de Pessoas a partir do businees Layer
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLista()
        {
            blPessoas blPessoas = new blPessoas();
            var lista = blPessoas.GetListas().Select(i => new { i.Id,
                                                                i.Nome,
                                                                i.Idade,
                                                                i.Email,
                                                                Profissao = System.Enum.GetName(typeof(BoutiqueDataContract.DataDefinition.Enuns.enProfissao), i.Profissao),
                                                                Status = System.Enum.GetName(typeof(BoutiqueDataContract.DataDefinition.Enuns.enStatus), i.Status)
                                                              });


            return new JsonResult(Newtonsoft.Json.JsonConvert.SerializeObject(lista));
        }

        /// <summary>
        /// Retornao numero de pessoas no banco de dados
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCount()
        {
            blPessoas blPessoas = new blPessoas();
                      
            return new JsonResult(Newtonsoft.Json.JsonConvert.SerializeObject(blPessoas.Count()));
        }

        /// <summary>
        /// Salva os dados de uma entrada no sistema
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveData()
        {
            byte[] bytes = new byte[10000];
            Request.Body.Read(bytes, 0, int.Parse(Request.ContentLength.ToString()));

            string receivedData = System.Text.ASCIIEncoding.UTF8.GetString(bytes);

            var pessoaObj = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(receivedData);

            Pessoa pessoa = new Pessoa() { Nome = pessoaObj["Nome"].ToString() ,
                                           Email = pessoaObj["Email"].ToString() ,
                                           Id = int.Parse(pessoaObj["Id"].ToString() =="" ? "0" : pessoaObj["Id"].ToString()) ,
                                           Idade = int.Parse(pessoaObj["Idade"].ToString()) ,
                                           Profissao = (BoutiqueDataContract.DataDefinition.Enuns.enProfissao)byte.Parse(pessoaObj["Profissao"].ToString()) ,
                                           Status = (pessoaObj["Desempregado"] ?? "0").ToString() == "False" ? BoutiqueDataContract.DataDefinition.Enuns.enStatus.Empregada : BoutiqueDataContract.DataDefinition.Enuns.enStatus.Desempregada };

            blPessoas blPessoas = new blPessoas();

            blPessoas.Save(pessoa);

            return new JsonResult("Dados salvos!");

        }

        /// <summary>
        /// Erro
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
