using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;

namespace Managers
{
    public class BulletGUIManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private TextMeshPro bulletText;
        #endregion

        #region Private Variables
        private PlayerData _data;

        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
        }
        public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onClicked += OnClicked;
            PlayerSignals.Instance.onShooted += OnShooted;
            PlayerSignals.Instance.onReloaded += OnReloaded;

        }

        private void UnsubscribeEvents()
        {

            InputSignals.Instance.onClicked -= OnClicked;
            PlayerSignals.Instance.onReloaded -= OnReloaded;

        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion


        private void OnPlay()
        {

        }

        private void OnClicked()
        {

        }

        private void OnShooted(int currentLoadedBulletCount, int remainBulletCount)
        {
            bulletText.text = ("|||   " + currentLoadedBulletCount + "/" + remainBulletCount);
        }
        private void OnReloaded(int currentLoad, int remainBulletCount)
        {
            bulletText.text = ("|||   " + currentLoad + "/" + remainBulletCount);
        }


        private void OnResetLevel()
        {

        }
    }
}