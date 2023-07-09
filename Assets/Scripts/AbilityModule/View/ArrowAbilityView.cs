using System;
using Gum.Composer;
using Gum.Composer.Generated;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.AbilityModule.View
{
    public class ArrowAbilityView : MonoBehaviour, IAbilityView
    {
        [Inject]
        private Collider2D _collider;

        [Inject]
        private Rigidbody2D _rigidbody2D;
        
        public AbilityType AbilityType => AbilityType.Arrow;

        private bool _isLaunched;

        public void Setup(Transform parentTransform)
        {
            transform.SetParent(parentTransform);
            transform.localPosition = Vector3.zero;
        }

        private void Update()
        {
            if (!_isLaunched)
            {
                return;
            }

            CalculateAngle();
        }

        private void CalculateAngle()
        {
            float angle = Mathf.Atan2(_rigidbody2D.velocity.y, _rigidbody2D.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        public void ProcessAbility(bool finishStatus)
        {
            throw new NotImplementedException();
        }

        public void LaunchFrom(Vector3 direction, float power)
        {
            transform.SetParent(null);
            TogglePhysics(true);
            _rigidbody2D.velocity = direction * power;
            _isLaunched = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.gameObject.name);

            Debug.Log(other.otherCollider.name);
        }

        public void TogglePhysics(bool value)
        {
            _rigidbody2D.isKinematic = !value;
            
            if (!value)
            {
                _rigidbody2D.velocity = Vector2.zero;
            } 
        }

        public Composition GetComposition()
        {
            return Composition.Create(new IAspect[] { new AbilityAspect(AbilityType) });
        }
    }
}