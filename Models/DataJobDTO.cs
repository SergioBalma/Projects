using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Models
{
    public class DataJobDTO
    {
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Default Guid not allow")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FilePathToProcess { get; set; }
        public DataJobStatus Status { get; set; } = DataJobStatus.New;
        public IEnumerable<string> Results { get; set; } = new List<string>();
        public IEnumerable<Link> Links { get; set; } = new List<Link>();
    }

    public enum DataJobStatus
    {
        New,
        Processing,
        Completed,
        None
    }

    public class Link
    {
        public string Rel { get; set; }
        public string Href { get; set; }
        public string Action { get; set; }
        public string[] Types { get; set; }
    }
}
