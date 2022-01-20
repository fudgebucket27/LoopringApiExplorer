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
        [HttpPost(Name = "CreateInfo")]
        public List<ApiTransaction> GetCreateInfo([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey, [RequiredAttribute] int accountId, int? limit = 50, int? offset = 0, long? start = 0, long? end = 0, List<Status>? statuses = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.CreateInfo(apiKey, accountId, limit.Value, offset.Value, start.Value, end.Value, statuses);
        }

        /// <summary>
        /// Returns a list Ethereum transactions from users for resetting exchange passwords.
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey">Your Loopring API Key</param>
        /// <param name="accountId" example="11087">Loopring account identifier</param>
        /// <param name="limit">The amount of transactions to retrieve</param>
        /// <param name="offset">The amount of transactions to skip</param>
        /// <param name="start">Lower bound of order's creation timestamp in millisecond (ex. 1567053142000)</param>
        /// <param name="end">Upper bound of order's creation timestamp in millisecond (ex. 1567053242000)</param>
        /// <param name="statuses" example='["received", "processing", "processed","failed"]'>Statuses which you would like to filter by</param>
        [HttpPost(Name = "UpdateInfo")]
        public List<ApiTransaction> GetUpdateInfo([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey, [RequiredAttribute] int accountId, int? limit = 50, int? offset = 0, long? start = 0, long? end = 0, List<Status>? statuses = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.UpdateInfo(apiKey, accountId, limit.Value, offset.Value, start.Value, end.Value, statuses);
        }

        /// <summary>
        /// Get the details of an order based on order hash.
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey">Your Loopring API Key</param>
        /// <param name="accountId" example="11087">Loopring account identifier</param>
        /// <param name="tokens">List of the tokens which you want returned</param>
        /// <returns>OrderDetails object filled with awesome order details</returns>
        [HttpPost(Name = "Balances")]
        public List<Balance> GetBalances([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, string apiKey, [RequiredAttribute] int accountId, string? tokens = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.Ballances(apiKey, accountId, tokens);
        }

        /// <summary>
        /// Returns a list of deposit records for the given user.
        /// </summary>
        /// <param name="apiEnvironment" example="UAT">The Loopring environment</param>
        /// <param name="apiKey">Your Loopring API Key</param>
        /// <param name="accountId" example="11087">Account ID, some hash query APIs doesnt need it if in hash query mode, check require flag of each API to see if its a must.</param>
        /// <param name="limit">Number of records to return</param>
        /// <param name="start">Start time in milliseconds - Default : 0L</param>
        /// <param name="end">End time in milliseconds - Default : 0L</param>
        /// <param name="statuses" example='["processing","processed","cancelling","cancelled","expired","failed"]'>Comma separated status values</param>
        /// <param name="tokenSymbol">Token to filter. If you want to return deposit records for all tokens, omit this parameter</param>
        /// <param name="offset">Number of records to skip - Default : 0L</param>
        /// <param name="hashes" example='[""]'>The hashes of the transactions, normally its L2 tx hash, except the deposit which uses L1 tx hash.</param>
        /// <returns>A list of deposit transactions. Are you paying attention?</returns>
        [HttpPost(Name = "Deposits")]
        public List<ApiDepositTransaction> GetDeposits([RequiredAttribute] ApiEnvironmentHelper.ApiEnvironment apiEnvironment, [RequiredAttribute] string apiKey, [RequiredAttribute] int accountId, int? limit = 50, long? start = 0, long? end = 0, [FromQuery] List<OrderStatus>? statuses = null, string? tokenSymbol = null, int? offset = 0, string[]? hashes = null)
        {
            string apiUrl = ApiEnvironmentHelper.GetApiEnvironment(apiEnvironment);
            SecureClient secureClient = new SecureClient(apiUrl);
            return secureClient.GetDeposits(apiKey, accountId, limit.Value, start.Value, end.Value, statuses, tokenSymbol, offset.Value, hashes);
        }

    }
}
