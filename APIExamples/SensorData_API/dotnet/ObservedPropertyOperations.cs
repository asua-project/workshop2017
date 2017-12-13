using ASUA.SensorDataApi.SDK.Api;
using ASUA.SensorDataApi.SDK.Client;
using ASUA.SensorDataApi.SDK.Model;
using System;
using System.Collections.Generic;

namespace ASUAWorkShop_APIExamples.SensorData_API
{
    class ObservedPropertyOperationsExamples
    {
        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/sdrest");
        ObservablePropertyApi observedPropertyApiInstance = null;

        public ObservedPropertyOperationsExamples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            observedPropertyApiInstance = new ObservablePropertyApi(conf);
        }


        public void GetObservedProperties()
        {
            //Get single observed property by it'S identifier
            ObservablePropertySummary observedPropertySummary = observedPropertyApiInstance.GetObservedProperty("observed_property_identifier");
            Console.WriteLine(observedPropertySummary.ToString());

            //Get detailed info about observed property by it's identifier
            ObservableProperty observedProperty = observedPropertyApiInstance.GetObservedPropertyExpanded("observed_property_identifier");
            Console.WriteLine(observedProperty.ToString());

            //Get all observed properties exists on service
            List<ObservablePropertySummary> observedPropertyList = observedPropertyApiInstance.GetAllObservedProperties();
            foreach (var item in observedPropertyList)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
