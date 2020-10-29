// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akash Kumar Singh"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Day_21_Assignment_Address_Book
{
    internal class CsvWriter1
    {
        private StreamWriter sw;
        private CultureInfo invariantCulture;

        public CsvWriter1(StreamWriter sw, CultureInfo invariantCulture)
        {
            this.sw = sw;
            this.invariantCulture = invariantCulture;
        }

       
    }
}