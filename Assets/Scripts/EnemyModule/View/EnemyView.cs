using System;
using Gum.Composer;
using Gum.Composer.Generated;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.EnemyModule.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.EnemyModule.View
{
    public class EnemyView : MonoComposable
    {
        [Inject]
        private Composition _enemyComposition;
        
        protected override IAspect[] GetAspects()
        {
            return Array.Empty<IAspect>();
        }
    }
}