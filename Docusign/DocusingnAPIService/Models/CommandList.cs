using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// List of all the commands with name, description, hot and cold responses
/// </summary>
namespace DocusingnAPIService.Models
{
    public class CommandList
    {
        public int CommandID { get; set; }
        public string Description { get; set; }
        public string HotResponse { get; set; }
        public string ColdResponse { get; set; }
    }
}