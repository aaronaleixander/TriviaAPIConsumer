using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    // Trivia API : https://opentdb.com/api.php?amount=10
    public class TriviaClient
    {
        
        static readonly HttpClient client = new HttpClient();

        // Static Constructor; Runs once per class.
        static TriviaClient()
        {
            // Base Address must end with /
            // there is a stack overflow post that goes into this detail.
            client.BaseAddress =
                new Uri("https://opentdb.com/");
        }


        /// <summary>
        /// Get Trivia questions from the TriviaAPI
        /// </summary>
        /// <param name="numQuestions"> Number of trivia questions to be returned </param>
        /// <returns></returns>
        public async Task<TriviaResponse> GetTriviaQuestions(byte numQuestions)
        {
            // URL to get information from
            HttpResponseMessage response = await client.GetAsync($"api.php?amount={numQuestions}");
            if (response.IsSuccessStatusCode)
            {
                // Return data and deserialize.
                string data = await response.Content.ReadAsStringAsync();
                TriviaResponse result = JsonConvert.DeserializeObject<TriviaResponse>(data);

                return result;
            }
            else
            {
                // If not successful - null is returned.
                return null;
            }
        }
    }


    // json2csharp.com
    public class Result
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }

    public class TriviaResponse
    {
        public int response_code { get; set; }
        public List<Result> results { get; set; }
    }
}
