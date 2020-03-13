using DocusingnAPIService.Interface;
using DocusingnAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DocusingnAPIService.Controllers
{
    public class DocusignAPIController : ApiController
    {
        private Command _command;

        public DocusignAPIController(Command command)
        {
            _command = command;
        }
        /// <summary>
        /// Get method to get all the commands decriptions and temperatures
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("api/DocusignAPI/GetCommandList")]
        public CommandTable GetCommandList()
        {
            CommandTable cmdlist = new CommandTable();
            cmdlist = _command.GetAllCommandList();
            return cmdlist;
        }
        /// <summary>
        /// This post method post the commands from the user input and get the responses
        /// </summary>
        /// <param name="cmdRequest"></param>
        /// <returns></returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/DocusignAPI/GetCommandResponse")]
        public CommandResponse GetCommandResponse([FromBody] CommandRequest cmdRequest)
        {

            var response = new CommandResponse();
            response = _command.GetRequestResponse(cmdRequest.TemperatureID, cmdRequest.Commands);
            return response;
        }
    }
}
