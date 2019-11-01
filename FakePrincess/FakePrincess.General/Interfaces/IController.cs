using FakePrincess.General.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.General.Interfaces
{
    public interface IController
    {
        ActionType GetAction();
    }
}
