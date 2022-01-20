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
        public OffchainFee GetOffChainFee([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey, [RequiredAttribute] int accountId, [RequiredAttribute] OffChainRequestType offChainRequestType, string? tokenSymbol = null, string? amount = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.OffchainFee(apiKey, accountId, offChainRequestType, tokenSymbol, amount);
        }

        /// <summary>
        /// Returns a list of Ethereum transactions from users for exchange account registration.
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey">Your Loopring API Key</param>
        /// <param name="accountId" example="10087">Loopring account identifier</param>
        /// <param name="limit">The amount of transactions to retrieve</param>
        /// <param name="offset">The amount of transactions to skip</param>
        /// <param name="start">Lower bound of order's creation timestamp in millisecond (ex. 1567053142000)</param>
        /// <param name="end">Upper bound of order's creation timestamp in millisecond (ex. 1567053242000)</param>
        /// <param name="statuses" example='["received", "processing", "processed","failed"]'>Statuses which you would like to filter by</param>
        /// <returns>List of Ethereum transactions from users for exchange account registration.</returns>
        [HttpPost(Name = "CreateInfo")]
        public List<ApiTransaction> CreateInfo([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey, [RequiredAttribute] int accountId, int? limit = 50, int? offset = 0, long? start = 0, long? end = 0, List<Status>? statuses = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.CreateInfo(apiKey, accountId, limit.Value, offset.Value, start.Value, end.Value, statuses);
        }
    }
}
