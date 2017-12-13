var ASUACEPSDK = require('asuacepsdk');

var apiClient = new ASUACEPSDK.ApiClient();
apiClient.basePath = "http://netigma.netcad.com.tr/cep";
apiClient.authentications.Authorization.apiKey = "YOUR_API_KEY";

var subscriptionApi = new ASUACEPSDK.SubscriptionApi(apiClient);

//Name of the rule that will be subscribed
var statementName = "rule_name_123";

var mailSubscription = new ASUACEPSDK.MailSubscription();
mailSubscription.mailAddress = "mail@address.com";
mailSubscription.message = "mail content";
mailSubscription.started = true;

//create mail subscription
subscriptionApi.createMailSubscription(statementName, mailSubscription, function (error, data, response) {
    if (!error) {
        console.log("Mail Subscription created, subscription key : " + data.key)
    }
})


//get all subscriptions
subscriptionApi.getAllSubscriptions(function (error, subscriptionList, response) {
    if (!error) {
        console.log("Total subscription : " + subscriptionDetail.length);
        console.log(JSON.stringify(subscriptionDetail));
    }
})


//get a subscription detail by it's id
var subscriptionKey = 123;
subscriptionApi.getSubscription(subscriptionKey, function (error, subscriptionDetail, response) {
    if (!error) {
        console.log("Subscription : " + JSON.stringify(subscriptionDetail));
    }
})

//start subscription it's id
var subscriptionKey = 123;
subscriptionApi.getSubscription(subscriptionKey, function (error, subscriptionDetail, response) {
    if (!error) {
        console.log("Subscription : " + JSON.stringify(subscriptionDetail));
    }
})







