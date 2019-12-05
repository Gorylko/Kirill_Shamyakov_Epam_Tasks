using FakePrincess.General.Entities.Enums;

namespace FakePrincess.General.Entities.Results
{
    public class BeforeActionResult
    {
        public ActionType Action { get; set; }

        public int Damage { get; set; }

        public bool IsCanMove { get; set; }

        public bool IsDamaged { get; set; }

        public bool IsGameOver { get; set; }

        public bool IsGameWone { get; set; }
    }
}
