﻿using System;
using BashSoft.Contracts;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public class InputReader : IReader
    {
        private const string EndCommand = "quit";
        private IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();

            while (true)
            {
                this.interpreter.InterpretCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();

                if (input.Equals(EndCommand))
                {
                    break;
                }
            }
        }
    }
}