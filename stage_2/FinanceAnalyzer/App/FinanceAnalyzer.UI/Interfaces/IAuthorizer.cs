using FinanceAnalyzer.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceAnalyzer.UI.Interfaces
{
    internal interface IAuthorizer
    {
        User GetCurrentUser();

        bool IsAuthorized();
    }
}
