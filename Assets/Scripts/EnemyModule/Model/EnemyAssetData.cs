using System;
using Gum.Composer;
using Gum.Composer.Generated;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.EnemyModule.Model
{
    [CreateAssetMenu(fileName = "New Enemy Asset Data", menuName = "GMTK2023/EnemyAssetData", order = 0)]
    public class EnemyAssetData : ScriptableObject, IComposable
    {
        [SerializeField]
        private EnemyType _enemyType;

        [SerializeField]
        private AbilityType _abilityType;

        [SerializeField]
        private int _initialDamageAmount;

        [SerializeField]
        private int _maxHealth;

        [SerializeField]
        private GameObject _enemyVisual;

        public Composition GetComposition()
        {
            return Composition.Create(new IAspect[]
            {
                new EnemyAspect(_enemyType),
                new AbilityAspect(_abilityType),
                new DamageAspect(_initialDamageAmount),
                new HealthAspect(_maxHealth),
                new GameObjectAspect(_enemyVisual)
            });
        }
    }
}