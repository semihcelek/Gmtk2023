using SemihCelek.Gmtk2023.AbilityModule.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.Factory
{
    public class AbilityViewFactory : IFactory<AbilityType, IAbilityView>
    {
        private readonly IInstantiator _instantiator;

        public AbilityViewFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IAbilityView Create(AbilityType abilityType)
        {
            return _instantiator.InstantiatePrefabResourceForComponent<IAbilityView>($"Prefabs/Abilities/{abilityType}");
        }
    }
}