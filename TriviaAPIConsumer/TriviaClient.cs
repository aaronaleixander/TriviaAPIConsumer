using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    //Trivia API : https://opentdb.com/api.php?amount=10
    public class TriviaClient
    {
        
        static readonly HttpClient client = new HttpClient();

        // Static Constructor; Runs once per class.
        static TriviaClient()
        {
            // Initialize all HttpCLient settings
        }


        
        public async Task<string> GetTriviaQuestions()
        {
            // URL to get information from
            HttpResponseMessage response = await client.GetAsync("https://opentdb.com/api.php?amount=5");
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
}
