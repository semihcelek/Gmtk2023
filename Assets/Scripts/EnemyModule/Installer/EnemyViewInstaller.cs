using SemihCelek.Gmtk2023.Controller;
using Zenject;

namespace SemihCelek.Gmtk2023.EnemyModule.Installer
{
    public class EnemyViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AIInputController>().AsSingle().NonLazy();
        }
    }
}