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
    public class BulletCreatorManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

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


        }

        private void UnsubscribeEvents()
        {

            InputSignals.Instance.onClicked -= OnClicked;

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
            CreateBullet();
        }

        private void CreateBullet()
        {
            GameObject bullet = PoolSignals.Instance.onGetObject(PoolEnums.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.eulerAngles = transform.eulerAngles;
            bullet.SetActive(true);
        }

        private void OnResetLevel()
        {

        }
    }
}