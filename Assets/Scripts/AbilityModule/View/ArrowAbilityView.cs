using Gum.Composer;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.AbilityModule.View
{
    public class ArrowAbilityView : MonoBehaviour, IAbilityView
    {
        public AbilityType AbilityType => AbilityType.Arrow;

        public Composition GetComposition()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(Transform parentTransform)
        {
            throw new System.NotImplementedException();
        }

        public void ProcessAbility(bool finishStatus)
        {
            throw new System.NotImplementedException();
        }
    }
}