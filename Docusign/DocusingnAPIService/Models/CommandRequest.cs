using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Command request method for user input
/// </summary>
namespace DocusingnAPIService.Models
{
    public class CommandRequest
    {
        public string TemperatureID { get; set; }
        public string Commands { get; set; }
    }
}