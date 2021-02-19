using System;

namespace ValuesTypes
{
    public struct A 
    {
        public int i;
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();


            Method(a);
            //a.i = 0
            Console.WriteLine(a.i);



            MethodRef(ref a);
            //a.i = 2
            Console.WriteLine(a.i);

            Console.ReadLine();
        }

        static void Method(A a)
        {
            a.i = 2;
        }

        static void MethodRef(ref A a)
        {
            a.i = 2;
        }
    }
}
