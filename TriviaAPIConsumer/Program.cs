﻿using System;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TriviaClient trivia = new TriviaClient();
            string result =  await trivia.GetTriviaQuestions();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}