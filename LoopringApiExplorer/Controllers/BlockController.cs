using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoopringSharp;
using System.ComponentModel.DataAnnotations;

namespace LoopringApiExplorer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockController : ControllerBase
    {
        /// <summary>
        /// Retrieves the layer 2 block by it's corresponding block id
        /// </summary>
        /// <param name="apiKey" example="">Your API key from Loopring</param>
        /// <param name="id" example="1">The layer 2 block id</param>
        [HttpPost(Name = "GetL2BlockInfo")]
        public L2BlockInfo Get([RequiredAttribute]string apiKey,[RequiredAttribute] int id)
        {
            SecureClient secureClient = new SecureClient("https://uat2.loopring.io");
            return secureClient.GetL2BlockInfo(apiKey, id);
        }
    }
}
