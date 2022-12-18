using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        #endregion

        #region Private Variables
        private PlayerData _data;
        private PlayerMovementController _movementController;
        private List<int> _playerUpgradeList;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
            _movementController = GetComponent<PlayerMovementController>();
        }
        public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += _movementController.OnPlay;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += _movementController.OnRestartLevel;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
            CoreGameSignals.Instance.onLevelFailed += _movementController.OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful += _movementController.OnLevelSuccess;
            PlayerSignals.Instance.onShooted += _movementController.OnShooted;
            PlayerSignals.Instance.onSlowMo += _movementController.OnSlowMo;
            SaveSignals.Instance.onInitializePlayerUpgrades += OnInitializePlayerUpgrades;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= _movementController.OnPlay;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= _movementController.OnRestartLevel;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
            CoreGameSignals.Instance.onLevelFailed -= _movementController.OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful -= _movementController.OnLevelSuccess;
            PlayerSignals.Instance.onShooted -= _movementController.OnShooted;
            PlayerSignals.Instance.onSlowMo -= _movementController.OnSlowMo;
            SaveSignals.Instance.onInitializePlayerUpgrades -= OnInitializePlayerUpgrades;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnPlay()
        {
            PlayerSignals.Instance.onSendPlayerDamage?.Invoke(_playerUpgradeList[0] * _data.DamageIncreaseValue + _data.DefaultDamage);
        }

        private void OnInitializePlayerUpgrades(List<int> upgradeList)
        {
            _playerUpgradeList = upgradeList;
        }


        private void OnResetLevel()
        {

        }
    }
}