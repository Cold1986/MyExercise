using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class AggregateTest
    {
        static void Main()
        {
            string sentence = "the quick brown fox jumps over the lazy dog";

            // Split the string into individual words.
            string[] words = sentence.Split(' ');

            // Prepend each word to the beginning of the 
            // new sentence to reverse the word order.
            //string reversed = words.Aggregate(Converters);
            
            //简写
            string reversed = words.Aggregate((workingSentence, next) =>
                                      next + " " + workingSentence);
            Console.WriteLine(reversed);


        }

        public static string Converters(string input1, string input2)
        {
            string a = input1;
            string b = input2;
            Console.WriteLine(input2 + " " + input1);
            return input2 + " " + input1;
        }
    }
}
