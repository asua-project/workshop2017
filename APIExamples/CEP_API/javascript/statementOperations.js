var ASUACEPSDK = require('asuacepsdk');

var apiClient = new ASUACEPSDK.ApiClient();
apiClient.basePath = "http://netigma.netcad.com.tr/cep";
apiClient.authentications.Authorization.apiKey = "YOUR_API_KEY";

var statementsApi = new ASUACEPSDK.StatementsApi(apiClient);

//define rule
var ruleStatement = "Select * from ObservationEvent where property = 'co2' and numericValue > 300";

var rule = new ASUACEPSDK.StatementSummary();
rule.epl = ruleStatement;
rule.name = "rule_name_123";
rule.isStarted = true;

//create rule
statementsApi.createStatement(rule, function (error, data, response) {
    if (!error) {
        console.log("Rule is created");
    }
})

//get all rules
statementsApi.getAllStatements(function (error, ruleList, response) {
    if (!error) {
        console.log("Total rule count : " + ruleList.length)
        console.log(JSON.stringify(ruleList))
    }
})

//get a rule by it's name
statementsApi.getAllStatements("rule_name_123", function (error, rule, response) {
    if (!error) {
        console.log(JSON.stringify(rule))
    }
})


//start rule
statementsApi.startStatement("rule_name_123", function (error, data, response) {
    if (!error) {
        console.log("Rule is started");
    }
})

//start rule
statementsApi.stopStatement("rule_name_123", function (error, data, response) {
    if (!error) {
        console.log("Rule is started");
    }
})

//destroy/delete rule
statementsApi.destroyStatement("rule_name_123", function (error, data, response) {
    if (!error) {
        console.log("Rule is destroyed");
    }
})






