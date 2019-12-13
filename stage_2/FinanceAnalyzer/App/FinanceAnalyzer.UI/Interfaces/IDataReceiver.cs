﻿using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.Shared.Results;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI.Interfaces
{
    internal interface IDataReceiver
    {
        DataResult<int> GetInt();

        DataResult<double> GetDouble();

        DataResult<ActionType> GetAction();
    }
}
