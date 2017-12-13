using ASUA.SensorDataApi.SDK.Api;
using ASUA.SensorDataApi.SDK.Client;
using ASUA.SensorDataApi.SDK.Model;
using System;
using System.Collections.Generic;

namespace ASUAWorkShop_APIExamples.SensorData_API
{
    class ProcedureOperationExamples
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/sdrest");
        ProcedureApi procedureApiInstance = null;

        public ProcedureOperationExamples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            procedureApiInstance = new ProcedureApi(conf);
        }


        public void GetProcedures()
        {
            //Get single procedure by it'S identifier
            Procedure procedure = procedureApiInstance.GetProcedure("my_procedure_identifier");
            Console.WriteLine(procedure.ToString());

            //Get all procedures
            List<ProcedureSummary> procedureList = procedureApiInstance.GetAllProcedures();
            foreach (var item in procedureList)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
