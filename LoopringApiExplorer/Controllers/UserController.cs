using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoopringSharp;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace LoopringApiExplorer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Retreives the fee you need to pay right now to carry out a transaction of a specified type
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey" example="">Your API key from Loopring</param>
        /// <param name="accountId" example="11087">The Loopring AccountId</param>
        /// <param name="offChainRequestType" example="Transfer">Off-chain request type</param>
        /// <param name="tokenSymbol">Required only for withdrawls - The token you wish to withdraw</param>
        /// <param name="amount">Required only for withdrawls - how much of that token you wish to withdraw</param>
        [HttpPost(Name = "GetOffchainFee")]
        public OffchainFee GetOffChainFee([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute]string apiKey, [RequiredAttribute] int accountId, [RequiredAttribute] OffChainRequestType offChainRequestType, string? tokenSymbol = null, string? amount = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.OffchainFee(apiKey, accountId, offChainRequestType, tokenSymbol, amount);
        }
    }
}
