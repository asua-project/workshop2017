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

        ObservationApi observationApi = new ObservationApi();

        try {
            //Get last observation for certain observed property and procedure
            Observation observation = observationApi.getLastObservation("procedure_example", "example_property");

            //Get last observations of each observed propery of procedure
            List<Observation> lastObservations = observationApi.getLastObservations("my_procedure");

             //Get last N observations for certain observed property and procedure
            ObservationList observationList = observationApi.getObservationsCount("my_procedure", "observed_property_identifier", 10);
            System.out.println("Total " + observationList.getObservedProperty() + " observation count : " + observationList.getCount());

        } catch (ApiException e) {
            System.err.println("Exception when calling procedureApi");
            e.printStackTrace();
        }
    }
}
