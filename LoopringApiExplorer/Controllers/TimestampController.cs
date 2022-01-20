using LoopringSharp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LoopringApiExplorer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TimestampController : ControllerBase
    {
        /// <summary>
        /// Retrieves the relayer's current time in milleseconds.
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        [HttpGet(Name = "RelayerTimestamp")]
        public long GetRelayerTimestamp([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.Timestamp();
        }
    }
}
