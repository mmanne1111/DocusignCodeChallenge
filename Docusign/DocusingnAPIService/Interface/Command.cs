
using DocusingnAPIService.Constants;
using DocusingnAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DocusingnAPIService.Interface
{
    public class Command : ICommand
    {
        public bool status = false;
        /// <summary>
        /// Get's the list of all the commands, descriptions
        /// </summary>
        /// <returns></returns>
        public CommandTable GetAllCommandList()
        {
            List<CommandList> cmdList = new List<CommandList>();
            List<Temperature> tempList = new List<Temperature>();
            DocusignData.Models.Data datalist = new DocusignData.Models.Data();
            tempList = GetTemperatures();

            foreach (var item in datalist.commands)
            {
                string hotResponse = "";
                string coldResponse = "";
                if (datalist.temperatureResponses.Count > 0)
                {
                    hotResponse = datalist.temperatureResponses.Find(x => (x.CommandID == item.CommandID) && (x.TemperatueId == 1)).Response.ToString();
                    coldResponse = datalist.temperatureResponses.Find(x => (x.CommandID == item.CommandID) && (x.TemperatueId == 2)).Response.ToString();
                }
                cmdList.Add(new CommandList { CommandID = item.CommandID, Description = item.CommandDescription, HotResponse = hotResponse, ColdResponse = coldResponse });
            }
            CommandTable cmd = new CommandTable
            {
                CommandList = cmdList,
                TemperatureList = tempList
            };


            return cmd;
        }
        //Get All the Temeratures List
        public List<Temperature> GetTemperatures()
        {
            List<Temperature> temp = new List<Temperature>();
            DocusignData.Models.Data datalist = new DocusignData.Models.Data();

            foreach (var item in datalist.temperatures)
            {
                temp.Add(new Temperature { TemperatueId = item.TemperatueId, TemperatueType = item.TemperatueType });
            }
            return temp;
        }
        /// <summary>
        /// This methods get the response for the user input of commands
        /// </summary>
        /// <param name="TemperatureID"></param>
        /// <param name="Commands"></param>
        /// <returns></returns>
        public CommandResponse GetRequestResponse(string TemperatureID, string Commands)
        {
            CommandResponse cmdres = new CommandResponse();
            var cmdlist = Commands.Split(',');
            bool InitialStage = false;
            InitialStage = CheckInitialStage(cmdlist);
            if (InitialStage == true)
            {
                cmdres.Response = GetResponse(cmdlist, TemperatureID);
            }
            else
            {
                cmdres.Response = Constant.FailedResponse;
            }
            return cmdres;
        }
        /// <summary>
        /// This Method valdiates the commands and return responses for specific temperatures
        /// </summary>
        /// <param name="cmdlist"></param>
        /// <param name="temperatureID"></param>
        /// <returns></returns>
        private string GetResponse(string[] cmdlist, string temperatureID)
        {
            int temperature = Convert.ToInt32(temperatureID);
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < cmdlist.Length; i++)
            {
                string item = CheckHotorColdResponse(cmdlist[i], temperature);
                bool exists = res.ToString().Contains(item);
                if(exists==false)
                {
                    res.Append(item);
                    res.Append(Constant.cmdSeperator);
                }
                

            }
            if (cmdlist.Length == 8 && temperature == 2)
            {
              
                    res = res.Remove(res.Length - 2, 2);
               
            }
            else
            {

                if (temperature == 2 )
                {
                    res.Append(Constant.FailedResponse);
                }
                else if(temperature==1 && (cmdlist.Length !=6 && status == false))
                {
                    res.Append(Constant.FailedResponse);
                }
                else
                {
                    res = res.Remove(res.Length - 2, 2);
                }
            }
            return res.ToString();
        }
        /// <summary>
        /// This method checks if it is hot or cold temperature and return responses based on the command
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private string CheckHotorColdResponse(string cmd, int temperature)
        {
            DocusignData.Models.Data datalist = new DocusignData.Models.Data();
            int cmdID = Convert.ToInt32(cmd);
            string tempResponse = "";

            if (datalist.temperatureResponses.Count > 0)
            {
                tempResponse = datalist.temperatureResponses.Find(x => (x.CommandID == cmdID) && (x.TemperatueId == temperature)).Response.ToString();

            }
            if (tempResponse.ToUpper().Contains(Constant.FailedResponse.ToUpper()))
            {
                status = true;
            }
            return tempResponse;


        }
        /// <summary>
        /// Validates the initial state with Pajamasa on
        /// </summary>
        /// <param name="cmdlist"></param>
        /// <returns></returns>
        private bool CheckInitialStage(string[] cmdlist)
        {
            bool InitialStatus = false;
            if (cmdlist[0] == Constant.InitialNumber)
            {
                InitialStatus = true;
            }
            return InitialStatus;
        }
    }
}