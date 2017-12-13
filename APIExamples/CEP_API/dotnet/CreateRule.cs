using ASUA.CEP.SDK.Api;
using ASUA.CEP.SDK.Client;
using ASUA.CEP.SDK.Model;
using System;

namespace ASUAWorkShop_APIExamples
{
    /// <summary>
    /// This class contains rule examles based on ObservationEvent
    /// </summary>
    public class CreateStatmentExamples
    {

        ApiClient apiClient = new ApiClient("http://netigma.netcad.com.tr/cep");
        StatementsApi statementApiInstance = null;

        public CreateStatmentExamples()
        {
            Configuration conf = new Configuration(apiClient);
            conf.AddApiKey("Authorization", "YOUR_API_KEY");

            statementApiInstance = new StatementsApi(conf);
        }


        void CreateSimpleRule_1()
        {
            try
            {
                //Define rule statement
                var statement = new StatementSummary()
                {
                    Epl = @"Select * from ObservationEvent(procedure = 'WaterSensor1' and property = 'WaterPh') where numericValue > 8.55",
                    Name = "my_first_rule", //rule name
                    IsStarted = true //start after creation
                };

                //Create the statement
                Message message0 = statementApiInstance.CreateStatement(statement);
                Console.WriteLine(message0._Message);

                //Stop the statement
                Message message1 = statementApiInstance.StopStatement("myfirstrule");
                Console.WriteLine(message1._Message);

                //Start the statement
                Message message2 = statementApiInstance.StartStatement("myfirstrule");
                Console.WriteLine(message2._Message);
            }
            catch (ApiException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        void CreateSimpleRule_2()
        {
            try
            {
                //Define rule statement
                string Epl = @"Select * from ObservationEvent(procedure = 'thermomete_1' and property = 'ambient_temperature') where numericValue < 10";

                var statement = new StatementSummary("my_second_rule", Epl, true);

                //Create the statement
                Message message0 = statementApiInstance.CreateStatement(statement);
                Console.WriteLine(message0._Message);
            }
            catch (ApiException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }



    }
}