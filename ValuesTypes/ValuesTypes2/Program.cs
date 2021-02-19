using System;

namespace ValuesTypes2
{
    public struct A
    {
        public int i;
    }

    class Program
    {
        static void Main(string[] args)
        {
            A? a = new A?();
            MethodRef(ref a);

            //Null reference exception
            Console.WriteLine(a.Value.i);

            Console.ReadLine();
        }

        static void MethodRef(ref A? a)
        {
            a = null;
        }
    }
}
