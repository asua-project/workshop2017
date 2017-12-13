package javaapplication3;

import asua.sensordatasdk.client.ApiClient;
import asua.sensordatasdk.client.ApiException;
import asua.sensordatasdk.client.Configuration;
import asua.sensordatasdk.client.auth.*;
import asua.sensordatasdk.client.api.*;
import asua.sensordatasdk.client.model.*;
import java.util.List;

public class JavaApplication3 {

    public static void main(String[] args) {

        ApiClient defaultClient = Configuration.getDefaultApiClient();
        defaultClient.setBasePath("http://netigma.netcad.com.tr/sdrest");

        // Configure API key authorization: Authorization
        ApiKeyAuth authorization = (ApiKeyAuth) defaultClient.getAuthentication("Authorization");
        authorization.setApiKey("YOUR API KEY");

        ProcedureApi procedureApi = new ProcedureApi();

        try {
            //get all procedures
            List<ProcedureSummary> procedureSummarys = procedureApi.getAllProcedures();

            //get single procedure by it^s identifier
            Procedure procedure = procedureApi.getProcedure("identifier_example");

        } catch (ApiException e) {
            System.err.println("Exception when calling procedureApi");
            e.printStackTrace();
        }
    }
}
