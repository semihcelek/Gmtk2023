using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Gum.Composer;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using SemihCelek.Gmtk2023.PlayerModule.View;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.View
{
    public class BowAbilityView : MonoBehaviour, IAbilityView
    {
        [Inject]
        private IAbilityView.Factory _abilityViewFactory;

        [Inject]
        private PlayerView _playerView;

        [SerializeField]
        private Transform _visualParentTransform;
        
        public AbilityType AbilityType => AbilityType.Bow;

        private AbilityType UtilizingAbility => AbilityType.Arrow;

        private ArrowAbilityView _shootingArrow;

        public void Setup(Transform parentTransform)
        {
            transform.SetParent(parentTransform);

            transform.localPosition = Vector3.zero;
        }
        
        private Sequence _sequence;

        private bool _isLocked;
        
        public void ProcessAbility(bool finishStatus)
        {
            if (_isLocked)
            {
                return;
            }
            
            if (finishStatus)
            {
                _sequence.Kill();
                
                ShotBowSequence().Forget();
                
                return;
            }

            if (_sequence != null)
            {
                _sequence.Kill();
            }
            
            _sequence = StretchBowSequence();
        }

        private async UniTask ShotBowSequence()
        {
            if (_shootingArrow ==null)
            {
                return;
            }
            
            // _shootingArrow.transform.SetParent(null);
            _shootingArrow.LaunchFrom(transform.right, 20);
            
        }

        private Sequence StretchBowSequence()
        {
            const float duration = 1.3f;

            ArrowAbilityView arrowView = (ArrowAbilityView)_abilityViewFactory.Create(UtilizingAbility);
            Transform arrowViewTransform = arrowView.transform;
            _shootingArrow = arrowView;
            
            arrowView.Setup(_visualParentTransform);
            
            Vector2 direction = _playerView.transform.position - transform.position;
            
            transform.right = direction;
            arrowViewTransform.right = direction;
            
            return DOTween.Sequence()
                .Join(arrowViewTransform.DOLocalMoveX(-0.5f, duration).SetEase(Ease.OutQuint));
        }

        public Composition GetComposition()
        {
            throw new NotImplementedException();
        }
    }
}