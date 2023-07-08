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
            
            _sequence = StretchBowSequence(0);
        }

        private async UniTask ShotBowSequence()
        {
            // _isLocked = true;
            
        }

        private Sequence StretchBowSequence(int angle)
        {
            Debug.Log("bu");
            const float duration = 1.3f;

            

            ArrowAbilityView arrowView = (ArrowAbilityView)_abilityViewFactory.Create(UtilizingAbility);
            arrowView.transform.SetParent(_visualParentTransform);
            arrowView.transform.localPosition = Vector3.zero;

            Vector3 yDifference = _playerView.transform.position + transform.position;

            float endValue = Vector3.Angle(_playerView.transform.position, transform.position);

            Debug.Log(endValue);
            
            return DOTween.Sequence()
                .Append(DOTween.To(()=>_visualParentTransform.localEulerAngles.z, (z) => _visualParentTransform.localEulerAngles = new Vector3(0,0,z -90), endValue, duration))
                .Join(arrowView.transform.DOLocalMoveX(-0.5f, duration).SetEase(Ease.OutQuint));
        }

        public Composition GetComposition()
        {
            throw new NotImplementedException();
        }
    }
}