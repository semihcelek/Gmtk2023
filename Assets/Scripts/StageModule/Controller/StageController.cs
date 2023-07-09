using SemihCelek.Gmtk2023.Model;
using SemihCelek.Gmtk2023.StageModule.View;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.StageModule.Controller
{
    public class StageController : IController, IInitializable
    {
        [Inject]
        private StageView[] _gameStages;
        
        public void Initialize()
        {
            InitializeStage(_gameStages[0]);
        }

        private void InitializeStage(StageView gameStage)
        {
            gameStage.InitializeStage();
        }
    }
}