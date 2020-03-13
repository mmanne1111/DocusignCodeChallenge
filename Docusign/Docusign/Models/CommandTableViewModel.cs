using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Command Table
/// </summary>
namespace Docusign.Models
{
    public class CommandTableViewModel
    {
        public int CommandID { get; set; }
        public string Description { get; set; }
        public string HotResponse { get; set; }
        public string ColdResponse { get; set; }
        
    }
}