﻿using SemihCelek.Gmtk2023.AbilityModule.Controller;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using SemihCelek.Gmtk2023.Model;
using SemihCelek.Gmtk2023.PlayerModule.View;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.PlayerModule.Controller
{
    public class PlayerController : IController, IInitializable
    {
        private readonly AbilityController _abilityController;

        private readonly AbilityContainer _playerAbilityContainer;

        private readonly PlayerView _playerView;

        private AbilityType _primaryAbility = AbilityType.Shield;
        
        public PlayerController(AbilityController abilityController, PlayerView playerView, AbilityContainer.Factory abilityContainerFactory)
        {
            _abilityController = abilityController;
            _playerView = playerView;

            _playerAbilityContainer = abilityContainerFactory.Create();
        }

        public void Initialize()
        {
            SetupAbilities();
        }

        private void SetupAbilities()
        {
            IAbilityView abilityView = _playerAbilityContainer[_primaryAbility];
            abilityView.Setup(_playerView.itemParentTransform, Vector2.zero);
        }

        public void ExecutePrimarySkill(bool isStarting)
        {
            _abilityController.ProcessAbility(_playerAbilityContainer[_primaryAbility], isStarting);
        }
    }
}