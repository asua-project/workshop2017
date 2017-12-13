using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;

namespace ASUAWorkShop_APIExamples.CEP_API.subscriptions
{
    class MQTT_Subscription_Examples
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        SubscriptionApi subscriptionApi = null;

        public MQTT_Subscription_Examples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            subscriptionApi = new SubscriptionApi(conf);
        }


        /// <summary>
        /// 
        /// </summary>
        public void CreateMQTTSubscription()
        {
            //Define mail subscription
            MQTTSubscription mqttSubscription = new MQTTSubscription()
            {
                Topic = "alarm",
                Message = "this is mqtt message content",
                Started = true,
                UseDefaultBroker = true,
            };

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateMQTTSubscription("my_rule_name", mqttSubscription);
            Console.WriteLine("Subscription key : " + response.Key);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateMQTTSubscription_ExternalMQTTServer()
        {
            //Define mail subscription with external mqtt broker
            MQTTSubscription mqttSubscription = new MQTTSubscription()
            {
                Topic = "alarm",
                Message = "this is a mqtt message from asua to for external mqtt broker",
                Started = true,
                UseDefaultBroker = false,
                Hostname = "my.mqtt.hostname",
                Port = 1883,
            };

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateMQTTSubscription("my_rule_name", mqttSubscription);
            Console.WriteLine("Subscription key : " + response.Key);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateMQTTSubscription_ExternalMQTTServer_Secure()
        {
            //Define mail subscription with external mqtt broker
            MQTTSubscription mqttSubscription = new MQTTSubscription()
            {
                Topic = "alarms/alarm_123",
                Message = "this is a mqtt message from asua to for external secure mqtt broker",
                Started = true,
                UseDefaultBroker = false,
                Hostname = "my.mqtt.hostname",
                Port = 1883,
                Credentials = new MQTTSubscriptionSecurity()
                {
                    Username = "my_mqtt_username",
                    Password = "my_mqtt_password"
                }
            };

            //Create subscription
            SubscriptionResponse response = subscriptionApi.CreateMQTTSubscription("my_rule_name", mqttSubscription);
            Console.WriteLine("Subscription key : " + response.Key);
        }

    }
}
