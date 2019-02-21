using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var moviePlayer = new MoviePlayer
            {
                CurrentMovie = Movie.StarWars4
            };

            MoviePlayer.MovieFinishedHandler handler = EjectDisc;

            // subscribe to an event
            moviePlayer.MovieFinished += handler;

            // unsubscribe
            // moviePlayer.MovieFinished -= handler; // will make it so we don't eject disk

            moviePlayer.MovieFinished += EjectDisc;

            moviePlayer.MovieFinished += () =>
            {
                Console.WriteLine("handle event with block body lambda");
            };

            moviePlayer.MovieFinished += () => Console.WriteLine("expression body");

            //Type is usually inferred from context so (string s) is unnecessary 
            moviePlayer.DiscEjected += (string s) => Console.WriteLine($"Ejecting {s}");

            moviePlayer.Play();

            Console.ReadLine(); // will wait for me to press enter before exiting
        }

        private static void FuncAndAction()
        {
            Func<string, string, int> func = (s1, s2) => s1.Length + s2.Length;
            Action<string, string, int> action = (s1, s2, i) => Console.WriteLine(s1 + s2 + i);
        }

        public static void EjectDisc()
        {
            Console.WriteLine("Ejecting Disc.");
        }
    }
}
