﻿using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        //error.DateTime - error.Level - error.Message
        const string DateFormat = "M/d/yyyy h:mm:ss tt";
        const string Format = "{0} - {1} - {2}";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formatedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);
            return formatedError;
        }
    }
}
