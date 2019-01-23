using RestSharp;
using System.Threading.Tasks;

namespace HandCash
{
    public enum Network // BSV Network
    {
        MainNet,
        TestNet
    }

    public static class Handle
    {
        public class HandleObj // Class Model for returned HandleObject JSON
        {
            public string ReceivingAddress { get; set; }
            public string PublicKey { get; set; }
        }

        // Main Synchronous Method.
        // Makes a Rest Request, handles the response & deserialises JSON to HandleObject Class
        public static HandleObj Get(string handle, Network network)
        {
            HandleObj handleObj = new HandleObj();
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

            IRestResponse<HandleObj> response = client.Execute<HandleObj>(request);
            handleObj = response.Data;

            return handleObj;
        }

        // Main Asynchronous Method.
        // Makes a Rest Request, handles the response & deserialises JSON to HandleObj Class
        public static async Task<HandleObj> GetAsync(string handle, Network network)
        {
            HandleObj handleObj = new HandleObj();
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

            var handleRequest = new RestRequest("/receivingAddress/{handle}", Method.GET);
            handleRequest.AddUrlSegment("handle", handle);

            var response = await client.ExecuteTaskAsync<HandleObj>(handleRequest);
            handleObj = response.Data;

            return handleObj;
        }

        public static string GetAddress(string handle, Network network) // Helper method to return the base58 encoded address pertaining to passed $handle
        {
            string address = Get(handle, network).ReceivingAddress;

            return address;
        }

        public static async Task<string> GetAddressAsync(string handle, Network network) // Async helper method to return the base58 encoded address pertaining to passed $handle
        {
            HandleObj handleObj = await GetAsync(handle, network);
            string address = handleObj.ReceivingAddress;

            return address;
        }

        public static string GetPublicKey(string handle, Network network) // Helper method to return the public key pertaining to passed $handle
        {
            string publicKey = Get(handle, network).PublicKey;

            return publicKey;
        }

        public static async Task<string> GetPublicKeyAsync(string handle, Network network) // Aync helper method to return the public key pertaining to passed $handle
        {
            HandleObj handleObj = await GetAsync(handle, network);
            string publicKey = handleObj.PublicKey;

            return publicKey;
        }

    }
}
