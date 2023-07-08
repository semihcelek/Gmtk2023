using SemihCelek.Gmtk2023.AbilityModule.Model;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.AbilityModule.Controller
{
    public class AbilityController : IController
    {
        public AbilityContainer SetupAbilities(AbilityContainer abilityContainer, AbilityType abilityType, Transform parentTransform)
        {
            IAbilityView abilityView = abilityContainer[abilityType];
            abilityView.Setup(parentTransform);

            return abilityContainer;
        }
        
        public void ProcessAbility(IAbilityView abilityView, bool isStarting)
        {
            abilityView.ProcessAbility(isStarting);
        }
    }
}