using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;
using System.Collections.Generic;

namespace ASUAWorkShop_APIExamples.CEP_API
{
    class SubscriptionExamples
    {
        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        SubscriptionApi subscriptionApi = null;

        public SubscriptionExamples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            subscriptionApi = new SubscriptionApi(conf);
        }


        public void RetrieveSubscriptions()
        {
            //Get single subscription by it's key
            int subscriptionKey = 123;
            SubscriptionModel subscriptionModel = subscriptionApi.GetSubscription(subscriptionKey);

            Console.WriteLine("Subscription Key : " + subscriptionModel.Id);
            Console.WriteLine(subscriptionModel.ToString());


            //Get all subscriptions
            List<SubscriptionModel> subscriptionList = subscriptionApi.GetAllSubscriptions();

            Console.WriteLine(subscriptionList.Count);
        }

        public void StartSubscriptions()
        {
            //Start single subscription by it's key
            int subscriptionKey = 123;
            Message message1 = subscriptionApi.Start(subscriptionKey);
        }

        public void StopSubscriptions()
        {
            //Stop single subscription by it's key
            int subscriptionKey = 123;
            Message message1 = subscriptionApi.Stop(subscriptionKey);
        }

        public void DeleteSubscriptions()
        {
            //Delete single subscription by it's key
            int subscriptionKey = 123;
            Message message1 = subscriptionApi.Unsubscribe(subscriptionKey);
        }

    }
}
