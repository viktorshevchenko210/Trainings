using System;

namespace ReferencesTypes
{
    class A
    {
        public int i = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            var temp = a;

            //a.i = 0
            Console.WriteLine(a.i);

            temp.i = 2;
            //a.i = 2
            Console.WriteLine(a.i);


            temp = null;
            //a is not null
            Console.WriteLine(a.i);

            Console.ReadLine();
        }
    }
}
