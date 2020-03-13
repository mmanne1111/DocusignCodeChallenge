using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocusingnAPIService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocusingnAPIService.Interface;
using DocusingnAPIService.Interface.Tests;
using DocusingnAPIService.Models;

namespace DocusingnAPIService.Controllers.Tests
{
    [TestClass()]
    public class DocusignAPIControllerTests
    {
    

        [TestMethod()]
        public void GetCommandListTest()
        {

            var service = new Command();
            var controller = new DocusignAPIController(service);

            var result = controller.GetCommandList();

            Assert.IsNotNull(result);

        }

        [TestMethod()]
        public void GetCommandResponseTest()
        {
            var service = new Command();
            CommandRequest req = new CommandRequest { TemperatureID = "3", Commands = "5" };
            var controller = new DocusignAPIController(service);

            var result = controller.GetCommandResponse(req);

            Assert.AreEqual("fail",result.Response);
        }

    
    }
}