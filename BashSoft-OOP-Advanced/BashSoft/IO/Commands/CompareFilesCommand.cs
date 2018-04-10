﻿using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Repository;
using BashSoft.SimpleJudge;

namespace BashSoft.IO.Commands
{
    [Alias("cmp")]
    public class CompareFilesCommand : Command, IExecutable
    {
        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string firstPath = Data[1];
            string secondPath = Data[2];
            this.judge.CompareContent(firstPath, secondPath);
        }
    }
}