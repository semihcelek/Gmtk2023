﻿using System;
using DG.Tweening;
using Gum.Composer;
using Gum.Composer.Generated;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.View
{
    public class ShieldAbilityView : MonoBehaviour, IAbilityView
    {
        [Inject]
        private Transform _rotationParentTransform;

        [Inject]
        private Collider2D _collider2D;

        public AbilityType AbilityType => AbilityType.Shield;

        private float _currentAngle;

        private Sequence _sequence;
        
        public void Setup(Transform parentTransform)
        {
            transform.SetParent(parentTransform);
            
            transform.localPosition = Vector3.zero;
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

        public Composition GetComposition()
        {
            return Composition.Create(new IAspect[] { new AbilityAspect(AbilityType) });
        }
    }
}