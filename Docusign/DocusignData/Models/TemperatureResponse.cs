using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Hot or Cold Temperature Response based on Command
/// </summary>
namespace DocusignData.Models
{
    public class TemperatureResponse
    {
        public int ResponseID { get; set; }

        public int TemperatueId { get; set; }
        public string Response { get; set; }
        public int CommandID { get; set; }
    }
}
