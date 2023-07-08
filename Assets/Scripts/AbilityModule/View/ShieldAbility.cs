using Gum.Composer;
using Gum.Composer.Generated;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.AbilityModule.View
{
    public class ShieldAbility : MonoComposable, IAbilityView
    {
        private Vector2 _centerPivot;
        
        public AbilityType AbilityType => AbilityType.Shield;

        public void Setup(Transform parentTransform, Vector2 centerPivotPosition)
        {
            transform.SetParent(parentTransform);
            transform.localPosition = Vector2.zero;
            _centerPivot = centerPivotPosition;
        }
        
        protected override IAspect[] GetAspects()
        {
            return new IAspect[] { new AbilityAspect(AbilityType) };
        }

        public void ProcessAbility(bool finishStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}