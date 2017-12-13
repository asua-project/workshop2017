var asuaSensorDataApi = require('asuasensordata');

var apiClient = new asuaSensorDataApi.ApiClient();
apiClient.basePath = "http://netigma.netcad.com.tr/sdrest";
apiClient.authentications.Authorization.apiKey = "YOUR_API_KEY";


var procedureApi = new asuaSensorDataApi.ProcedureApi(apiClient);

