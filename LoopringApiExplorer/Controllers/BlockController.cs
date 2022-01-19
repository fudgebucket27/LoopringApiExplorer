using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoopringSharp;
using System.ComponentModel.DataAnnotations;

namespace LoopringApiExplorer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        /// <summary>
        /// Retrieves the Loopring layer 2 block by it's corresponding block id
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey" example="">Your API key from Loopring</param>
        /// <param name="id" example="1">The layer 2 block id</param>
        [HttpPost(Name = "GetL2BlockInfo")]
        public L2BlockInfo GetL2BlockInfo([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute]string apiKey,[RequiredAttribute] int id)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.GetL2BlockInfo(apiKey, id);
        }

        /// <summary>
        /// Retrieves pending requests to be packed into the next Loopring layer 2 block
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey" example="">Your API key from Loopring</param>
        [HttpPost(Name = "GetL2PendingRequests")]
        public  List<PendingRequest> GetL2PendingRequests([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.GetPendingRequests(apiKey);
        }
    }
}
