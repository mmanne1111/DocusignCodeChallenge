using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocusingnAPIService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocusingnAPIService.Models;

namespace DocusingnAPIService.Interface.Tests
{
    [TestClass()]
    public class CommandTests
    {
        [TestMethod()]
        public void GetAllCommandListTest()
        {
            var service = new Command();
            var result = service.GetAllCommandList();
            Assert.IsTrue(result.CommandList.Count > 0);
        }

        [TestMethod()]
        public void GetTemperaturesTest()
        {
            var service = new Command();
            var result = service.GetTemperatures();
            
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetRequestResponseTest()
        {
            var service = new Command();
            CommandRequest req = new CommandRequest { TemperatureID = "1", Commands = "8, 6, 4, 2, 1, 7" };
            var result = service.GetRequestResponse(req.TemperatureID,req.Commands);
            string expected = "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house";
            Assert.AreEqual(expected,result.Response);
        }
    }
}