using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Models;
using WebApplicationDemo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataProcessorController : ControllerBase
    {
        private readonly ILogger<DataProcessorController> _logger;

        // GET: ​/api​/DataProcessor​/GetAllData
        [HttpGet]
        [Route("GetAllDataJobs")]
        public async Task<ActionResult<DataJobResponse>> GetAllDataJobs()
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", DataJobDTOs = null });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.GetAllDataJobs();

                if (response != null)
                {
                    return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status200OK, Description = "OK", DataJobDTOs = (List<DataJobDTO>)response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", DataJobDTOs = null });
            }
            return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", DataJobDTOs = null });

        }



        // GET: ​/api​/DataProcessor​/GetDataJobsByStatus
        [HttpGet]
        [Route("GetDataJobsByStatus")]
        public async Task<ActionResult<DataJobResponse>> GetDataJobsByStatus(DataJobStatus status)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", DataJobDTOs = null });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.GetDataJobsByStatus(status);

                if (response != null)
                {
                    return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status200OK, Description = "OK", DataJobDTOs = (List<DataJobDTO>)response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", DataJobDTOs = null });
            }
            return new ActionResult<DataJobResponse>(new DataJobResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", DataJobDTOs = null });

        }


        // GET: ​/api​/DataProcessor​/GetDataJob
        [HttpGet]
        [Route("GetDataJob")]
        public async Task<ActionResult<DataJobItemResponse>> GetDataJob(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", DataJobDTOs = null });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.GetDataJob(id);

                if (response != null)
                {
                    return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status200OK, Description = "OK", DataJobDTOs = response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", DataJobDTOs = null });
            }
            return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", DataJobDTOs = null });

        }



        // POST: ​/api​/DataProcessor​/CreateDataJob
        [HttpPost]
        [Route("CreateDataJob")]
        public async Task<ActionResult<DataJobItemResponse>> CreateDataJob(DataJobDTO dataJob)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", DataJobDTOs = null });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.Create(dataJob);

                if (response != null)
                {
                    return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status201Created, Description = "OK", DataJobDTOs = response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", DataJobDTOs = null });
            }
            return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", DataJobDTOs = null });

        }


        // PUT: ​/api​/DataProcessor​/UpdateDataJob
        [HttpPut]
        [Route("UpdateDataJob")]
        public async Task<ActionResult<DataJobItemResponse>> UpdateDataJob(DataJobDTO dataJob)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", DataJobDTOs = null });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.Update(dataJob);

                if (response != null)
                {
                    return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status200OK, Description = "OK", DataJobDTOs = response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", DataJobDTOs = null });
            }
            return new ActionResult<DataJobItemResponse>(new DataJobItemResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", DataJobDTOs = null });

        }


        // DELETE: ​/api​/DataProcessor​/Delete
        [HttpDelete]
        [Route("DeleteDataJob")]
        public async Task<ActionResult<EmptyResponse>> DeleteDataJob(Guid dataJobId)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<EmptyResponse>(new EmptyResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input" });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                service.Delete(dataJobId);
                return new ActionResult<EmptyResponse>(new EmptyResponse { Code = StatusCodes.Status200OK, Description = "OK" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<EmptyResponse>(new EmptyResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO" });
            }

        }

        // PUT: ​/api​/DataProcessor​/StartBackgroundProcess
        [HttpPut]
        [Route("StartBackgroundProcess")]
        public async Task<ActionResult<BooleanResponse>> StartBackgroundProcess(Guid dataJobId)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<BooleanResponse>(new BooleanResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", Successful = false });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.StartBackgroundProcess(dataJobId);

                if (response == true)
                {
                    return new ActionResult<BooleanResponse>(new BooleanResponse { Code = StatusCodes.Status200OK, Description = "OK", Successful = true });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<BooleanResponse>(new BooleanResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", Successful = false });
            }
            return new ActionResult<BooleanResponse>(new BooleanResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", Successful = false });

        }



        // GET: ​/api​/DataProcessor​/GetBackgroundProcessStatus
        [HttpGet]
        [Route("GetBackgroundProcessStatus")]
        public async Task<ActionResult<DataJobStatusResponse>> GetBackgroundProcessStatus(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<DataJobStatusResponse>(new DataJobStatusResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input" });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.GetBackgroundProcessStatus(id);

                if (response != DataJobStatus.None)
                {
                    return new ActionResult<DataJobStatusResponse>(new DataJobStatusResponse { Code = StatusCodes.Status200OK, Description = "OK", dataJobStatus = response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<DataJobStatusResponse>(new DataJobStatusResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO" });
            }
            return new ActionResult<DataJobStatusResponse>(new DataJobStatusResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found" });

        }


        // GET: ​/api​/DataProcessor​/GetBackgroundProcessResults
        [HttpGet]
        [Route("GetBackgroundProcessResults")]
        public async Task<ActionResult<ListStringResponse>> GetBackgroundProcessResults(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return new ActionResult<ListStringResponse>(new ListStringResponse { Code = StatusCodes.Status400BadRequest, Description = "Invalid input", ResultList=null });
            }


            DataProcessorService service = new DataProcessorService();
            try
            {
                var response = service.GetBackgroundProcessResults(id);

                if (response != null)
                {
                    return new ActionResult<ListStringResponse>(new ListStringResponse { Code = StatusCodes.Status200OK, Description = "OK", ResultList = response });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ActionResult<ListStringResponse>(new ListStringResponse { Code = StatusCodes.Status500InternalServerError, Description = "KO", ResultList = null });
            }
            return new ActionResult<ListStringResponse>(new ListStringResponse { Code = StatusCodes.Status204NoContent, Description = "Data not found", ResultList = null });

        }
        
    }
}
