using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;

namespace ASUAWorkShop_APIExamples.CEP_API.subscriptions
{
    class WebHook_Subscription_Examples
    {
        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        SubscriptionApi subscriptionApi = null;

        public WebHook_Subscription_Examples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            subscriptionApi = new SubscriptionApi(conf);
        }

        public void CreateWebHookSubsription_POST()
        {
            //Define mail subscription with external mqtt broker
            WebHookSubscription webHookSubscription = new WebHookSubscription()
            {
                Url = "httt://my.website.com",
                Content = "this is webhook content", // optional
                Started = true,
                Method = "POST", // All HTTP headers(GET, POST, PUT, DELETE etc.) supported
                Headers = new System.Collections.Generic.Dictionary<string, string> // optional
                {
                    { "header_name", "header_value" },
                    { "header_name2", "header_value2" }
                }
            };

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateWebHookSubscription("my_rule_name", webHookSubscription);
            Console.WriteLine("Subscription key : " + response.Key);
        }

        public void CreateWebHookSubsription_GET()
        {
            //Define mail subscription with external mqtt broker
            WebHookSubscription webHookSubscription = new WebHookSubscription()
            {
                Url = "httt://my.website.com",
                Started = true,
                Method = "GET"
            };

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateWebHookSubscription("my_rule_name", webHookSubscription);
            Console.WriteLine("Subscription key : " + response.Key);
        }

    }
}
