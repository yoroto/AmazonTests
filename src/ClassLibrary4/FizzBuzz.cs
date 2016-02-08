using System;

namespace ClassLibrary4
{
    public class FizzBuzz
    {
        public static void Boom()
        {
            for(var i = 1; i <= 100; i++)
            {
                var text = string.Empty;
                if (i % 3 == 0)
                    text = "Fizz";
                if (i % 5 == 0)
                    text += "Buzz";
                Console.WriteLine(text == string.Empty ? i.ToString() : text);
            }
        }
    }
}
