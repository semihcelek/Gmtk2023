using Gum.Composer;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.Model
{
    public interface IAbilityView : IComposable
    {
        AbilityType AbilityType { get; }

        void Setup(Transform parentTransform, Vector2 centerPivotPosition);

        void ProcessAbility(bool finishStatus);
        
        class Factory : PlaceholderFactory<AbilityType, IAbilityView> { }
    }
}