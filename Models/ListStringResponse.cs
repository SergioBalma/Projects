using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class ListStringResponse
    {
        public int Code { get; set; }
        public string Description { get; set; }

        public List<string> ResultList { get; set; }
    }
}
