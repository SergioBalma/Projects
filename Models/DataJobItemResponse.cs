using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class DataJobItemResponse
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public DataJobDTO DataJobDTOs { get; set; }
    }
}
