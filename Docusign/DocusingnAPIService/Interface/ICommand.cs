using DocusingnAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Icommand Interface 
/// </summary>
namespace DocusingnAPIService.Interface
{
    interface ICommand
    {

        CommandTable GetAllCommandList();
        CommandResponse GetRequestResponse(string TemperatureID, string Commands);
    }
}
