using System;
using System.Linq;
using static TP3.MovieCollection;
using System.Collections.Generic;

using System.Threading;

namespace TP3
{
    class Program
    {

        static void Main(string[] args)
        {
            // exercice1();
            exercice2();
        }

        static void exercice1() 
        {
            //Exercice 1
            
            List<WaltDisneyMovies> mv = new MovieCollection().Movies;
            
            //Count all movies.
            Console.WriteLine("Movies : " + mv.Count());
            
            //Count all movies with the letter e.
            Console.WriteLine("Movies with e : " + mv.Count(x => x.Title.Contains("e")));

            int countLetterF = 0;
            foreach (WaltDisneyMovies item in mv)
            {
                countLetterF += item.Title.Count(x => x == 'f');
            }
            
            //Count how many time the letter f is in all the titles from this list.
            Console.WriteLine("Letter f in all the titles from the list : " + countLetterF);


            //Display the title of the film with the higher budget.
            mv.Sort(delegate(WaltDisneyMovies x, WaltDisneyMovies y) {
                return y.Budget.CompareTo(x.Budget);
            });
            Console.WriteLine("Title of the film with the higher budget: " + mv[0].Title);

            //Display the title of the movie with the lowest box office.
            mv.Sort(delegate(WaltDisneyMovies x, WaltDisneyMovies y) {
                return x.Budget.CompareTo(y.Budget);
            });
            Console.WriteLine("Title of the film with the lowest budget: " + mv[0].Title);

            //Order the movies by reversed alphabetical order and print the first 11 of the list.
            mv.Sort((x,y) => string.Compare(y.Title, x.Title));
            Console.WriteLine("11 reversed alphabetical movies");
            for (int i = 0 ; i < 11 ; i++) {
                Console.WriteLine(mv[i].Title);
            }

            // Count all the movies made before 1980
            Console.WriteLine(mv.Count(x => x.ReleaseDate.Year < 1980));


            //Display the average running time of movies having a vowel as the first letter.
            int moviesStartByAVowel = 0;
            double average = 0;
            foreach (WaltDisneyMovies item in mv)
            {
                if (item.Title[0] == 'A' ||item.Title[0] == 'E' ||item.Title[0] == 'I' ||item.Title[0] == 'O' ||item.Title[0] == 'U' ||item.Title[0] == 'Y') {
                    moviesStartByAVowel++;
                    average += item.RunningTime;
                }
            }
            Console.WriteLine("Average running time of movies having a vowel as the first letter : " + average/moviesStartByAVowel);

            //Calculate the mean of all Budget / Box Office of every movie ever
            double boxOfficeTotal = 0;
            foreach (WaltDisneyMovies item in mv)
            {
                boxOfficeTotal += item.BoxOffice;
            }
            Console.WriteLine("The mean of all Budget : " + boxOfficeTotal/mv.Count());

            //Print all movies with the letter H or W in the title, but not the letter I or T.
            foreach (WaltDisneyMovies item in mv)
            {
                if ( (item.Title.Contains('H') || item.Title.Contains('W') || item.Title.Contains('h') || item.Title.Contains('w') ) ) {
                    if (!( item.Title.Contains('I') || item.Title.Contains('T') || item.Title.Contains('i') || item.Title.Contains('t') ) ) {
                        Console.WriteLine(item.Title);
                    }
                }
            }
        }

        static void exercice2()
        {
            Thread th1 = new Thread(new ThreadStart(ps3));
            th1.Start();

        }

        static void ps1()
        {
            affichage('_',10000,50);
        }

        static void ps2()
        {
            affichage('*',11000,40);
        }

        static void ps3()
        {
            affichage('°',9000,20);
        }

        static void affichage(char character, int duree, int intervalle)
        {
            Mutex mx = new Mutex();
            mx.WaitOne();
            for (int i = 0 ; i < duree/intervalle ; i++ )
            {
                Console.WriteLine(character);
                Thread.Sleep(intervalle);
            }
            mx.ReleaseMutex();
        }
    }
}
