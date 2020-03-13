using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Command Table List which contains Temperatures and Commands
/// </summary>
namespace Docusign.Models
{
    public class CommandListViewModel
    {
        public List<CommandTableViewModel> CommandList { get; set; }
        public List<TemperatureViewModel> TemperatureList { get; set; }
    }
}