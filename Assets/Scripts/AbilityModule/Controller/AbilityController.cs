using SemihCelek.Gmtk2023.AbilityModule.Model;
using SemihCelek.Gmtk2023.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.Controller
{
    public class AbilityController : IController
    {
        public void ProcessAbility(IAbilityView abilityView, bool isStarting)
        {
            abilityView.ProcessAbility(isStarting);
        }
    }
}