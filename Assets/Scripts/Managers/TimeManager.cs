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
    public class TimeManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        #endregion

        #region Private Variables

        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {

        }
        public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {

            PlayerSignals.Instance.onSlowMo += OnSlowMo;

        }

        private void UnsubscribeEvents()
        {

            PlayerSignals.Instance.onSlowMo -= OnSlowMo;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlay()
        {

        }

        private void OnSlowMo(bool isSlowMo)
        {
            if (isSlowMo)
            {
                Time.timeScale = 0.5f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        private void OnResetLevel()
        {

        }
    }
}