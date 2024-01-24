using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class DataJobStatusResponse
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public DataJobStatus? dataJobStatus { get; set; }
    }
}
