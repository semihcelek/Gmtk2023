using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.PlayerModule
{
    public class PlayerViewInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _itemParentTransform;

        [SerializeField]
        private Transform _pivotTransform;
        
        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>().FromComponentInChildren().AsSingle();

            Container.Bind<Transform>().FromInstance(_itemParentTransform);

            Container.Bind<Vector3>().FromMethod(() => _pivotTransform.localPosition);
        }
    }
}