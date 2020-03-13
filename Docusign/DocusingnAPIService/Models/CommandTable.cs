using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Command Table List which contains Temperatures and Commands
/// </summary>

namespace DocusingnAPIService.Models
{
    public class CommandTable
    {
        public List<CommandList> CommandList { get; set; }
        public List<Temperature> TemperatureList { get; set; }
    }
}