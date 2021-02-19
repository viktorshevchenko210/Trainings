using System;
using System.Collections.Generic;

namespace CapturedVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Action> actions = CreateActions();
            foreach (Action action in actions)
            {
                action();
            }
            //5 will be captured

            Console.ReadKey();
        }

        static List<Action> CreateActions()
        {
            List<Action> actions = new List<Action>();
            for(int i = 0; i < 5; i++)
            {
                actions.Add(() => Console.WriteLine(i));
            }

            return actions;
        }
    }
}
