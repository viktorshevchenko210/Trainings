using System;
using System.Collections.Generic;

namespace CapturedVariables2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Action> actions = CreateActions();

            foreach(var action in actions)
            {
                action();
            }

            //Variable is not captured
            //Different variables on every iteration
            //0
            //1
            //2
            //3
            //4


            Console.ReadKey();
        }

        static List<Action> CreateActions()
        {
            List<Action> actions = new List<Action>();

            for(int i = 0; i < 5; i++)
            {
                LambdaContext context = new LambdaContext();
                context.variable = i;
                actions.Add(context.Method);
            }

            return actions;
        }
    }
}
