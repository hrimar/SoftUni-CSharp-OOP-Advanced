﻿using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        //private IRepository repository;
        //private IUnitFactory unitFactory;

        public Command(string[] data)
        {
            this.Data = data;
            //this.Repository = repository;
            //this.UnitFactory = unitFactory;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        //protected IRepository Repository
        //{
        //    get { return this.repository; }
        //    private set { this.repository = value; }
        //}

        //protected IUnitFactory UnitFactory
        //{
        //    get { return this.unitFactory; }
        //    private set { this.unitFactory = value; }
        //}


        public abstract string Execute();


    }
}
