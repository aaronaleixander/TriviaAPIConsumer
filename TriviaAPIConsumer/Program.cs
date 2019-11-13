using System;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TriviaClient trivia = new TriviaClient();
            TriviaResponse result =  await trivia.GetTriviaQuestions(3); // 3 questions returned

            Console.WriteLine("Received trivia questions. \n\n");

            Console.WriteLine(result.results[0].question);

            Console.ReadKey();
        }
    }
}
