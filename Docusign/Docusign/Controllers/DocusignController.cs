using Docusign.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
/// <summary>
/// Home Page Controller 
/// </summary>
namespace Docusign.Controllers
{
    public class DocusignController : Controller
    {
        private readonly string apiUrl = ConfigurationManager.AppSettings["baseurl"];
        HttpClient client;

        public DocusignController()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// This method return the view of the command Table description
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            CommandListViewModel cmdList = new CommandListViewModel();
            try
            {
                string commandListUrl = apiUrl + "GetCommandList";

                HttpResponseMessage responseMessage = await client.GetAsync(commandListUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    cmdList = new JavaScriptSerializer().Deserialize<CommandListViewModel>(responseData);

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return View(cmdList);
        }



    }
}