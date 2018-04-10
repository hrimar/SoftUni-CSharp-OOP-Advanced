﻿using System;
using System.Linq;
using System.Reflection;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Repository;
using BashSoft.SimpleJudge;

namespace BashSoft.IO
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0];
            commandName = commandName.ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string command)
        {

            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Type typeOfCommand = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(type => type.GetCustomAttributes(typeof(AliasAttribute))
                    .Where(atr => atr.Equals(command))
                    .ToArray().Length > 0);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand
                            .SetValue(exe,
                            fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;

            //switch (command)
            //{
            //    case "open":
            //        return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "mkdir":
            //        return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "ls":
            //        return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "cmp":
            //        return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "cdrel":
            //        return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "cdabs":
            //        return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "readdb":
            //        return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "help":
            //        return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "filter":
            //        return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "order":
            //        return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "show":
            //        return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "dropdb":
            //        return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "display":
            //        return new DisplayCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //        break;
            //    default:
            //        throw new InvalidCommandException(input);
            //}
        }
    }
}