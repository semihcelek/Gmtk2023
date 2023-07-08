using Gum.Composer;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.Model
{
    public interface IAbilityView : IComposable
    {
        AbilityType AbilityType { get; }

        void Setup(Transform parentTransform);

        void ProcessAbility(bool finishStatus);
        
        class Factory : PlaceholderFactory<AbilityType, IAbilityView> { }
    }
}