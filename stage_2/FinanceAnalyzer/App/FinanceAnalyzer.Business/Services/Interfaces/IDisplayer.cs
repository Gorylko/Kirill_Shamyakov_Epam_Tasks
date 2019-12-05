﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IDisplayer
    {
        void DisplayCollection<T>(IReadOnlyCollection<T> collection);

        void DisplayStartMenu();

        void DisplayMessage(string message);

    }
}
