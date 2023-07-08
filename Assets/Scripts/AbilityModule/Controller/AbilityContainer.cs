using System.Collections.Generic;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.Controller
{
    public class AbilityContainer
    {
        private readonly Dictionary<AbilityType ,IAbilityView> _abilityViews = new Dictionary<AbilityType, IAbilityView>();

        private readonly IAbilityView.Factory _abilityFactory;

        public AbilityContainer(IAbilityView.Factory abilityFactory)
        {
            _abilityFactory = abilityFactory;
        }

        public IAbilityView this[AbilityType abilityType]
        {
            get
            {
                if (_abilityViews.ContainsKey(abilityType))
                {
                    return _abilityViews[abilityType];
                }

                IAbilityView abilityView = _abilityFactory.Create(abilityType);
                
                _abilityViews.Add(abilityType, abilityView);
                
                return abilityView;
            }
        }
        
        public class Factory : PlaceholderFactory<AbilityContainer> { }
    }
}