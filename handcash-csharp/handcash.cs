using RestSharp;
using System;

namespace Handcash
{
    public class Handcash
    {
        public class HandleObject // Returned base model from the call to the HandCash API
        {
            public string ReceivingAddress { get; set; }
            public string PublicKey { get; set; }
        }

        public enum Network // Desired BCH Network on which the API call will return
        {
            MainNet,
            TestNet
        }

        public static HandleObject GetObject(String handle, Network network) // Main Method that wraps returned JSON into the HandleObject Class
        {
            HandleObject handleObject = new HandleObject();
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
            handleObject = handleResponse.Data;

            return handleObject;
        }

        public static String GetReceivingAddress(String handle, Network network) // Helper method to return the base58 encoded address pertaining to passed $handle
        {
            HandleObject handleObject = GetObject(handle, network);
            string receivingAddress = handleObject.ReceivingAddress;

            return receivingAddress;
        }

        public static String GetPublicKey (String handle, Network network) // Helper method to return the public key pertaining to passed $handle
        {
            HandleObject handleObject = GetObject(handle, network);
            string publicKey = handleObject.PublicKey;

            return publicKey;
        }

    }
}
