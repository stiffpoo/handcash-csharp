using RestSharp;
using System.Threading.Tasks;

namespace HandCash
{
    public static class Handle
    {
        public class HandleObject // Class Model for returned HandleObject JSON
        {
            public string ReceivingAddress { get; set; }
            public string CashAddr { get; set; }
            public string PublicKey { get; set; }
        }

        public enum Network // BCH Network
        {
            MainNet,
            TestNet
        }

        // Main Synchronous Method.
        // Makes a Rest Request, handles the response & deserialises JSON to HandleObject Class
        public static HandleObject Get(string handle, Network network)
        {
            HandleObject handleObj = new HandleObject();
            string url = "";
            if (network == Network.MainNet)
            {
                url = "https://api.handcash.io/api/";
            }
            else
            {
                url = "https://test-api.handcash.io/api/";
            }
            var client = new RestClient(url);

            var request = new RestRequest("/receivingAddress/{handle}", Method.GET);
            request.AddUrlSegment("handle", handle);

            IRestResponse<HandleObject> handleResponse = client.Execute<HandleObject>(request);
            handleObj = handleResponse.Data;

            return handleObj;
        }

        // Main Asynchronous Method.
        // Makes a Rest Request, handles the response & deserialises JSON to HandleObject Class
        public static async Task<HandleObject> GetAsync(string handle, Network network)
        {
            HandleObject handleObj = new HandleObject();
            string url = "";
            if (network == Network.MainNet)
            {
                url = "https://api.handcash.io/api/";
            }
            else
            {
                url = "https://test-api.handcash.io/api/";
            }
            var handleClient = new RestClient(url);

            var handleRequest = new RestRequest("/receivingAddress/{handle}", Method.GET);
            handleRequest.AddUrlSegment("handle", handle);

            var handleResponse = await handleClient.ExecuteTaskAsync<HandleObject>(handleRequest);
            handleObj = handleResponse.Data;

            return handleObj;
        }

        public static string GetCashAddr(string handle, Network network) // Helper method to return the bech32 encoded address pertaining to passed $handle
        {
            string cashAddr = Get(handle, network).CashAddr;

            return cashAddr;
        }

        public static async Task<string> GetCashAddrAsync(string handle, Network network) // Async helper method to return the bech32 encoded address pertaining to passed $handle
        {
            HandleObject handleObj = await GetAsync(handle, network);
            string cashAddr = handleObj.CashAddr;

            return cashAddr;
        }

        public static string GetLegacyAddr(string handle, Network network) // Helper method to return the base58 encoded address pertaining to passed $handle
        {
            string legacyAddr = Get(handle, network).ReceivingAddress;

            return legacyAddr;
        }

        public static async Task<string> GetLegacyAddrAsync(string handle, Network network) // Async helper method to return the base58 encoded address pertaining to passed $handle
        {
            HandleObject handleObj = await GetAsync(handle, network);
            string legacyAddr = handleObj.ReceivingAddress;

            return legacyAddr;
        }

        public static string GetPublicKey(string handle, Network network) // Helper method to return the public key pertaining to passed $handle
        {
            string publicKey = Get(handle, network).PublicKey;

            return publicKey;
        }

        public static async Task<string> GetPublicKeyAsync(string handle, Network network) // Aync helper method to return the public key pertaining to passed $handle
        {
            HandleObject handleObj = await GetAsync(handle, network);
            string publicKey = handleObj.PublicKey;

            return publicKey;
        }

    }
}
