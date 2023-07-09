using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.Installer.ComponentInstallers
{
    public class TransformInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _transform;

        public override void InstallBindings()
        {
            if (ReferenceEquals(_transform, null))
            {
                Container.Bind<Transform>().FromComponentOn(gameObject).AsSingle();
            }
            
            Container.Bind<Transform>().FromInstance(_transform).AsSingle();
        }
    }
}