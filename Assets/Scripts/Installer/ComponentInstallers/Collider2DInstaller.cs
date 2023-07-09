using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.Installer.ComponentInstallers
{
    public class Collider2DInstaller : MonoInstaller
    {
        [SerializeField]
        private Collider2D _collider;

        public override void InstallBindings()
        {
            if (ReferenceEquals(_collider, null))
            {
                Container.Bind<Collider2D>().FromComponentOn(gameObject).AsSingle();
            }
            
            Container.Bind<Collider2D>().FromInstance(_collider).AsSingle();
        }
    }
}