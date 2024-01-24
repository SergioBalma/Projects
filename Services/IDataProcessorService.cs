using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Sevices
{
    public interface IDataProcessorService
    {
        IEnumerable<DataJobDTO> GetAllDataJobs();
        IEnumerable<DataJobDTO> GetDataJobsByStatus(DataJobStatus status);
        DataJobDTO GetDataJob(Guid id);
        DataJobDTO Create(DataJobDTO dataJob);
        DataJobDTO Update(DataJobDTO dataJob);
        void Delete(Guid dataJobID);
        bool StartBackgroundProcess(Guid dataJobId);
        DataJobStatus GetBackgroundProcessStatus(Guid dataJobId);
        List<string> GetBackgroundProcessResults(Guid dataJobId);
    }
}
