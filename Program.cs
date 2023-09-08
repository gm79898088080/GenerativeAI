using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GenerativeAI.AiConfiguration;


namespace FunctionsAI
{
    public class AIFunctios
    {

        static async Task Main(string[] args)
        {

            string userPrompt;
            string userApiKey;
            string userApiUrl;
            int userMaxTokens;
            double userTemperature;
            double userPresenceOfPenalty;

            userPrompt = "Olá chatGPT boa tarde, como você está?";
            userApiKey = "INSERT YOUR API KEY";
            userApiUrl = "https://api.openai.com/v1/engines/text-davinci-002/completions";
            userMaxTokens = 50;
            userTemperature = 0.2;
            userPresenceOfPenalty = 1;

            OpenAI chamada = new OpenAI(userPrompt,userApiKey, userApiUrl, userMaxTokens,userTemperature,userPresenceOfPenalty );

            await chamada.ReturnRespApi();


        }
        
    }
        

}