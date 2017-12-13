using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;

namespace ASUAWorkShop_APIExamples.CEP_API.subscriptions
{
    /// <summary>
    /// Before using FCM subscription method, please check the Device operations since you need to register at least one device to achive FCM subscription
    /// </summary>
    class FCM_Subscription_Example
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        SubscriptionApi subscriptionApi = null;

        public FCM_Subscription_Example()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            subscriptionApi = new SubscriptionApi(conf);
        }

        void CreateFCM_Notification_Subscription()
        {
            FCMSubscription fcmSubscription = new FCMSubscription()
            {
                DeviceIdentifier = "my_device_identifier",
                Started = true,
            };

            SubscriptionResponse subscriptionResponse = subscriptionApi.CreateFCMSubscription("my_rule_name", fcmSubscription);
            Console.WriteLine("Subscription Key : " + subscriptionResponse.Key);
        }

        void CreateFCM_Notification_Subscription_CustomBody()
        {
            FCMSubscription fcmSubscription = new FCMSubscription()
            {
                DeviceIdentifier = "my_device_identifier",
                Started = true,
                IsNotification = true,
                NotificationBody = "This is custom notification body",
                NotificationTitle = "This is custom notification title"
            };

            SubscriptionResponse subscriptionResponse = subscriptionApi.CreateFCMSubscription("my_rule_name", fcmSubscription);
            Console.WriteLine("Subscription Key : " + subscriptionResponse.Key);
        }



    }
}
