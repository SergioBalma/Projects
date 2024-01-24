using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;


namespace WebApplicationDemo.Services
{
    public class DataProcessorService
    {
        public List<DataJobDTO> DataJobDTOs { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DataProcessorService()
        {
            Initialize();
        }


        public DataJobDTO Create(DataJobDTO dataJob)
        {
            DataJobDTOs.Add(dataJob);

            return GetDataJob(dataJob.Id);
        }

        public IEnumerable<DataJobDTO> GetAllDataJobs()
        {
            if (this.DataJobDTOs != null & this.DataJobDTOs.Count > 0)
            {
                return this.DataJobDTOs.ToList();
            }
            return null;
        }

        public List<string> GetBackgroundProcessResults(Guid dataJobId)
        {
            if (this.DataJobDTOs != null & this.DataJobDTOs.Count > 0 && GetDataJob(dataJobId) != null)
            {
                return this.DataJobDTOs.Where(x => (Guid)x.Id == (Guid)dataJobId).FirstOrDefault().Results.ToList();
            }
            return null;
        }

        public DataJobStatus GetBackgroundProcessStatus(Guid dataJobId)
        {
            if (this.DataJobDTOs != null & this.DataJobDTOs.Count > 0 && GetDataJob(dataJobId)!=null)
            {
                return this.DataJobDTOs.Where(x => (Guid)x.Id == (Guid)dataJobId).FirstOrDefault().Status;
            }
            return DataJobStatus.None;
        }

        public DataJobDTO GetDataJob(Guid id)
        {
            if (this.DataJobDTOs != null & this.DataJobDTOs.Count > 0)
            {
                return this.DataJobDTOs.Where(x => (Guid)x.Id== (Guid)id).FirstOrDefault();
            }
            return null;
        }

        public IEnumerable<DataJobDTO> GetDataJobsByStatus(DataJobStatus status)
        {
            if (this.DataJobDTOs != null & this.DataJobDTOs.Count > 0)
            {
                return this.DataJobDTOs.Where(x=> x.Status== status).ToList();
            }
            return null;
        }

        public bool StartBackgroundProcess(Guid dataJobId)
        {
            try
            {
                var dataJob = GetDataJob(dataJobId);

                if (dataJob != null)
                {
                    dataJob.Status = DataJobStatus.Processing;
                    Update(dataJob);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public DataJobDTO Update(DataJobDTO dataJob)
        {
            if (GetDataJob(dataJob.Id) != null)
            {
                Delete(dataJob.Id);
                Create(dataJob);
            }
            else
            {
                Create(dataJob);
            }

            return GetDataJob(dataJob.Id);
        }

        public void Delete(Guid dataJobID)
        {
            DataJobDTOs.RemoveAll(x => x.Id == dataJobID);
        }


        #region Helper Methods

        protected void Initialize()
        {
            this.DataJobDTOs = new List<DataJobDTO>()
            {
                new DataJobDTO()
                {
                    Id=Guid.Parse("161406f4-a5db-4465-aeb7-ac19c0e39fae"), //Guid.NewGuid(), change for testing purposes
                    Name= "Name1",
                    FilePathToProcess= @"C:\Path1\",
                    Status = DataJobStatus.New,
                    Results= new List<string>(){ "Result1", "Result11" },

                    Links= new List<Link>()
                    {
                        new Link(){
                            Action= "Action1",
                            Href= "Href1",
                            Rel= "Rel1",
                            Types= new string[]{  "Type1", "Type11"}
                        }
                    }

                },
                new DataJobDTO()
                {
                    Id=Guid.Parse("261406f4-a5db-4465-aeb7-ac19c0e39fae"), //Guid.NewGuid(), change for testing purposes
                    Name= "Name2",
                    FilePathToProcess= @"C:\Path2\",
                    Status = DataJobStatus.Processing,
                    Results= new List<string>(){ "Result2", "Result22" },

                    Links= new List<Link>()
                    {
                        new Link(){
                            Action= "Action2",
                            Href= "Href2",
                            Rel= "Rel2",
                            Types= new string[]{  "Type2", "Type12"}
                        }
                    }

                },
                    new DataJobDTO()
                {
                    Id=Guid.Parse("361406f4-a5db-4465-aeb7-ac19c0e39fae"), //Guid.NewGuid(), change for testing purposes
                    Name= "Name3",
                    FilePathToProcess= @"C:\Path3\",
                    Status = DataJobStatus.Completed,
                    Results= new List<string>(){ "Result2", "Result33" },

                    Links= new List<Link>()
                    {
                        new Link(){
                            Action= "Action3",
                            Href= "Href3",
                            Rel= "Rel3",
                            Types= new string[]{  "Type3", "Type13"}
                        }
                    }

                },
            };
        }

        #endregion
    }
}
