using LoopringSharp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LoopringApiExplorer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AmmController : ControllerBase
    {
        /// <summary>
        /// Retrieves the AMM pool trade transactions
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="ammPoolAddress" example="0x049a02fa9bc6bd54a2937e67d174cc69a9194f8e">The AMM pool address</param>
        /// <param name="limit" example="50">The number of trades to return</param>
        /// <param name="offset" example="0">The number of trades to skip</param>
        [HttpGet(Name = "AmmPoolTrades")]
        public  AmmPoolTrades GetAmmPoolTrades([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string ammPoolAddress, [RequiredAttribute] int limit, [RequiredAttribute] int offset)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.GetAmmPoolTrades(ammPoolAddress, limit, offset);
        }

        /// <summary>
        /// Retrieves the users AMM join exit transactions
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey" example="">Your API key from Loopring</param>
        /// <param name="accountId" example="10083">The Loopring Layer 2 account Id</param>
        /// <param name="start">Date time in milliseconds to start fetching AMM transactions</param>
        /// <param name="end">Date time in milliseconds to end fetching AMM transactions</param>
        /// <param name="limit" example="50">How many transactions to return per call</param>
        /// <param name="offset" example="50">How many transactions to skip</param>
        /// <param name="txTypes">Transaction type to filter on</param>
        /// <param name="txStatus">Transaction status to filter on</param>
        /// <param name="ammPoolAddress">The address of the AMM pool</param>
        [HttpPost(Name = "AmmJoinExitTransactions")]
        public  AmmJoinExitTransactions GetAmmJoinExitTransactions([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey, [RequiredAttribute] int accountId, long? start = 0, long? end = 0, int limit = 50, int offset = 0, string? txTypes = null, string? txStatus = null, string? ammPoolAddress = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.GetAmmJoinExitTransactions(apiKey, accountId, start.Value, end.Value, limit, offset, txTypes, txStatus, ammPoolAddress);
        }
    }
}
