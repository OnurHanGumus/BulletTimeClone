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
            CoreGameSignals.Instance.onRestartLevel += _movementController.OnReset;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
            CoreGameSignals.Instance.onLevelFailed += _movementController.OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful += _movementController.OnLevelSuccess;
            PlayerSignals.Instance.onShooted += _movementController.OnShooted;
            PlayerSignals.Instance.onSlowMo += _movementController.OnSlowMo;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= _movementController.OnPlay;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= _movementController.OnReset;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
            CoreGameSignals.Instance.onLevelFailed -= _movementController.OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful -= _movementController.OnLevelSuccess;
            PlayerSignals.Instance.onShooted -= _movementController.OnShooted;
            PlayerSignals.Instance.onSlowMo -= _movementController.OnSlowMo;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlay()
        {

        }
        private void Update()
        {
            var pos = new Vector3(transform.position.x, transform.position.y, 0);
            Debug.Log(Camera.main.WorldToScreenPoint(pos));
        }
        private void OnResetLevel()
        {

        }
    }
}