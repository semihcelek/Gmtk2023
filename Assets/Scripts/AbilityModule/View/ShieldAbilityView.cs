using System;
using DG.Tweening;
using Gum.Composer;
using Gum.Composer.Generated;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.AbilityModule.View
{
    public class ShieldAbilityView : MonoComposable, IAbilityView
    {
        public AbilityType AbilityType => AbilityType.Shield;

        [SerializeField]
        private Transform _rotationParentTransform;

        private Vector2 _centerPivot;

        private float _currentAngle;

        private Sequence _sequence;
        
        public void Setup(Transform parentTransform, Vector2 centerPivotPosition)
        {
            transform.SetParent(parentTransform);
            
            transform.localPosition = Vector3.zero;
            
            _centerPivot = centerPivotPosition;
        }
        
        protected override IAspect[] GetAspects()
        {
            return new IAspect[] { new AbilityAspect(AbilityType)  };
        }

        public void ProcessAbility(bool finishStatus)
        {
            if (finishStatus)
            {
                _sequence.Kill();
                _sequence = AnimationSequence(90);
                return;
            }

            if (_sequence != null)
            {
                _sequence.Kill();
            }
            
            _sequence = AnimationSequence(0);
        }

        private Sequence AnimationSequence(int angle)
        {
            const float duration = 1.3f;

            Vector3 rotation = new Vector3(0,0, angle);
            
            return DOTween.Sequence()
                .Append(_rotationParentTransform.DOLocalRotate(rotation, duration).SetEase(Ease.InOutSine));
        } 
    }
}