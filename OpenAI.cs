using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerativeAI.AiConfiguration
{
    public class OpenAI
    {
        private string _prompt;
        private string _apiKey;
        private string _apiUrl;
        private int _maxTokens;
        private double _temperatureApi;
        private double _presenceOfPenalty;

        //Constructor
        public OpenAI(string prompt, string apiKey, string apiUrl, int maxTokens, double temperature, double presenceOfPenalty)
        {
            // These are requirements required by OpenAI to manipulate Artificial Intelligence
            _prompt = prompt;
            _apiKey = apiKey;
            _apiUrl = apiUrl;
            _maxTokens = maxTokens;
            _temperatureApi = temperature;
            _presenceOfPenalty = presenceOfPenalty;
        }

        // Creating get and set methods
        public string Prompt
        {
            get { return _prompt; }
            set
            {
                if ( value != null)
                {
                    _prompt = value;
                }
                else
                {
                    Console.WriteLine("Ação invalida.");
                }
            }
        }

        public string ApiKey
        {
            set { _apiKey = value; }
        }

        public string ApiUrl
        {
            get { return _apiKey; }
            set
            {
                if(value != null)
                {
                    _apiUrl = value;
                }
                else
                {
                    Console.WriteLine("Comando Invalido.");
                }
            }
        }

        public int MaxTokens
        {
            get { return _maxTokens; }
            set
            {
                if (value != 0)
                {
                    _maxTokens = value;
                }
                else
                {
                    Console.WriteLine("Comando Invalido.");
                }
            }
        }

        public double Temperatute
        {
            get { return _temperatureApi; }
            set
            {
                if (value != 0)
                {
                    _temperatureApi = value;
                }
                else
                {
                    Console.WriteLine("Comando Invalido.");
                }
            }
        }

        public double PresenceOfPenalty
        {
            get { return _presenceOfPenalty; }
            set
            {
                if (value != 0)
                {
                    _presenceOfPenalty = value;
                }
                else
                {
                    Console.WriteLine("Comando Invalido.");
                }
            }
        }

        public async Task ReturnRespApi()
        {
            // Creating 'request' to store/communicate with the API 
            var requestData = new
            {
                prompt = _prompt,
                max_tokens = _maxTokens,
                temperature = _temperatureApi,
                presence_penalty = _presenceOfPenalty,
            };

            // Convert to JSON
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            using (var httpCliente  = new HttpClient())
            {
                // Setting the authorization header with the API key
                httpCliente.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                // Configuring the media type header directly in StringContent
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Sending the POST request to the API
                var response = await httpCliente.PostAsync(_apiUrl, content );
                    
                if (response.IsSuccessStatusCode)
                {
                    var responseContente = await response.Content.ReadAsStringAsync();
                    var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContente);
                    var generatedText = responseData.choices[0].text;
                    Console.WriteLine(generatedText);

                }
                else
                {
                    Console.WriteLine("Requisição invalida.");
                    
                }


            }
        }
        
    }
}
