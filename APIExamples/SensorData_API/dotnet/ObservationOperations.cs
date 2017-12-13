using ASUA.SensorDataApi.SDK.Api;
using ASUA.SensorDataApi.SDK.Client;
using ASUA.SensorDataApi.SDK.Model;
using System;
using System.Collections.Generic;

namespace ASUAWorkShop_APIExamples.SensorData_API
{
    class ObservationOperationExamples
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/sdrest");
        ObservationApi observationApiInstance = null;

        public ObservationOperationExamples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            observationApiInstance = new ObservationApi(conf);
        }

        void GetObservations()
        {
            //Get last observations of each observed propery of procedure
            List<Observation> lastObservations = observationApiInstance.GetLastObservations("my_procedure");
            foreach (var item in lastObservations)
            {
                Console.WriteLine(item.ObservedProperty + " : " + item.ResultTime + " , " + item.Value.ToString());
            }


            //Get last observation for certain observed property and procedure
            Observation singleObservation = observationApiInstance.GetLastObservation("my_procedure", "observed_property_identifier");
            Console.WriteLine(singleObservation.ResultTime + " , " + singleObservation.Value);


            //Get last N observations for certain observed property and procedure
            ObservationList observationList = observationApiInstance.GetObservationsCount("my_procedure", "observed_property_identifier", 10);
            Console.WriteLine("Total " + observationList.ObservedProperty + " observation count : " + observationList.Count);
            foreach (var item in observationList.Observations)
            {
                Console.WriteLine(item.ResultTime + " , " + item.Value.ToString());
            }


            //Get observations between two time.
            var startTime = "2017-12-13T13:00:00Z";
            var endtTime = "2017-12-13T15:30:00Z";

            var timespan = startTime + "/" + endtTime;

            ObservationList observationList_2 = observationApiInstance.GetObservations("my_procedure", "observed_property_identifier", timespan);
            Console.WriteLine(string.Format("Total observation count between {0} - {1} : {3} ", startTime, endtTime, observationList.Count));
            foreach (var item in observationList.Observations)
            {
                Console.WriteLine(item.ResultTime + " , " + item.Value.ToString());
            }
        }

        void SendSingleObservation()
        {
            SimpleObservation observation1 = new SimpleObservation()
            {
                ResultTime = DateTime.Now,
                Value = 123,
            };

            observationApiInstance.SendSingleObservation("my_procedure", "observed_property_identifier", observation1);


            SimpleObservation observation2 = new SimpleObservation(DateTime.Now, 456);
            observationApiInstance.SendSingleObservation("my_procedure", "count_property", observation2);


            SimpleObservation observation3 = new SimpleObservation(DateTime.Now, 23.213);
            observationApiInstance.SendSingleObservation("my_procedure", "numeric_property", observation3);


            SimpleObservation observation4 = new SimpleObservation(DateTime.Now, true);
            observationApiInstance.SendSingleObservation("my_procedure", "boolean_property", observation4);


            SimpleObservation observation5 = new SimpleObservation(DateTime.Now, "string value");
            observationApiInstance.SendSingleObservation("my_procedure", "text_property", observation4);


            //TODO - add geometry data

        }
    }
}
