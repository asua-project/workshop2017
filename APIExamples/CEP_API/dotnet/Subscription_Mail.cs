using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;

namespace ASUAWorkShop_APIExamples.CEP_API.subscriptions
{
    class Mail_Subscription_Examples
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        SubscriptionApi subscriptionApi = null;

        public Mail_Subscription_Examples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            subscriptionApi = new SubscriptionApi(conf);
        }


        public void CreateMailSubscription()
        {
            //Define mail subscription
            MailSubscription mailSubscription1 = new MailSubscription("test@test.com", "Rule triggered", true);

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateMailSubscription("my_rule_name", mailSubscription1);
            Console.WriteLine("Subscription key : " + response.Key);
        }

    }
}
