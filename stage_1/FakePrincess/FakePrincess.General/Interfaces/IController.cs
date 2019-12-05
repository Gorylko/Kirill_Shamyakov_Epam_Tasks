using FakePrincess.General.Entities.Enums;

namespace FakePrincess.General.Interfaces
{
    public interface IController
    {
        ActionType GetAction();

        bool IsReplay();
    }
}
