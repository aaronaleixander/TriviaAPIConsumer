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


        
        public async Task<string> GetTriviaQuestions()
        {
            // URL to get information from
            HttpResponseMessage response = await client.GetAsync("api.php?amount=5");
            if (response.IsSuccessStatusCode)
            {
                // Return data
                return await response.Content.ReadAsStringAsync();
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
