using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// All the Data such as Temperatures, Commands, Descriptions are added to invidual Lists
/// </summary>
namespace DocusignData.Models
{
    public class Data
    {

        public List<Temperature> temperatures = new List<Temperature>
            {
                new Temperature { TemperatueId = 1, TemperatueType = "Hot" },
                new Temperature { TemperatueId = 2, TemperatueType = "Cold" }
            };
        public List<Command> commands = new List<Command>
            {
                new Command{CommandID=1, CommandDescription="Put on footwear"},
                new Command{CommandID=2, CommandDescription="Put on headwear"},
                new Command{CommandID=3, CommandDescription="Put on socks"},
                new Command{CommandID=4, CommandDescription="Put on shirt"},
                new Command{CommandID=5, CommandDescription="Put on jacket"},
                new Command{CommandID=6, CommandDescription="Put on pants"},
                new Command{CommandID=7, CommandDescription="Leave house"},
                new Command{CommandID=8, CommandDescription="Take off pajamas"}
            };
        public List<TemperatureResponse> temperatureResponses = new List<TemperatureResponse>
            {
                new TemperatureResponse{CommandID=1,TemperatueId=1,ResponseID=1,Response="sandals"},
                new TemperatureResponse{CommandID=1,TemperatueId=2,ResponseID=1,Response="boots"},
                new TemperatureResponse{CommandID=2,TemperatueId=1,ResponseID=1,Response="sun visor"},
                new TemperatureResponse{CommandID=2,TemperatueId=2,ResponseID=1,Response="hat"},
                new TemperatureResponse{CommandID=3,TemperatueId=1,ResponseID=1,Response="fail"},
                new TemperatureResponse{CommandID=3,TemperatueId=2,ResponseID=1,Response="socks"},
                new TemperatureResponse{CommandID=4,TemperatueId=1,ResponseID=1,Response="t-shirt"},
                new TemperatureResponse{CommandID=4,TemperatueId=2,ResponseID=1,Response="shirt"},
                new TemperatureResponse{CommandID=5,TemperatueId=1,ResponseID=1,Response="fail"},
                new TemperatureResponse{CommandID=5,TemperatueId=2,ResponseID=1,Response="jacket"},
                new TemperatureResponse{CommandID=6,TemperatueId=1,ResponseID=1,Response="shorts"},
                new TemperatureResponse{CommandID=6,TemperatueId=2,ResponseID=1,Response="pants"},
                new TemperatureResponse{CommandID=7,TemperatueId=1,ResponseID=1,Response="leaving house"},
                new TemperatureResponse{CommandID=7,TemperatueId=2,ResponseID=1,Response="leaving house"},
                new TemperatureResponse{CommandID=8,TemperatueId=1,ResponseID=1,Response="Removing PJs"},
                new TemperatureResponse{CommandID=8,TemperatueId=2,ResponseID=1,Response="Removing PJs"}

            };


    }
}
