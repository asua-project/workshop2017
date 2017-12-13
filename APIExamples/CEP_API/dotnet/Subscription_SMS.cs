using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;

namespace ASUAWorkShop_APIExamples.CEP_API.subscriptions
{
    class SMS_Subscription_Examples
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        SubscriptionApi subscriptionApi = null;

        public SMS_Subscription_Examples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            subscriptionApi = new SubscriptionApi(conf);
        }

        public void CreateSMSSubsription()
        {
            //Define mail subscription with external mqtt broker
            SMSSubscription smsSubscription = new SMSSubscription()
            {
                TelNumber = "0500123456",
                Message = "SMS Content",
                Started = true
            };

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateSMSSubscription("my_rule_name", smsSubscription);
            Console.WriteLine("Subscription key : " + response.Key);
        }


    }
}
