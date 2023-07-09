using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.Installer.ComponentInstallers
{
    public class Rigidbody2DInstaller : MonoInstaller
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        public override void InstallBindings()
        {
            if (ReferenceEquals(_rigidbody2D, null))
            {
                Container.Bind<Rigidbody2D>().FromComponentOn(gameObject).AsSingle();
            }
            
            Container.Bind<Rigidbody2D>().FromInstance(_rigidbody2D).AsSingle();
        }
    }
}