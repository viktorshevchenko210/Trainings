using System;
using System.Collections.Generic;

namespace CapturedVariables3
{
    class Program
    {
        static void Main(string[] args)
        {
            var actions = CreateActions();

            foreach(var action in actions)
            {
                action();
            }

            //Variable is not captured 

            Console.ReadKey();
        }

        static List<Action> CreateActions()
        {
            List<Action> actions = new List<Action>();

            List<string> names = new List<string>() { "x", "y", "z" };

            foreach (var name in names)
            {
                actions.Add(() => Console.WriteLine(name));
            }

            return actions;
        }
    }
}
