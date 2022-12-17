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
        private int _bulletCount = 176;
        private int _currentLoad = 17;
        private int _loadCapacity = 17;


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
            if (_currentLoad <= 0)
            {
                Reload();
            }
            else
            {
                CreateBullet();
            }
        }

        private void Reload()
        {
            Debug.Log("Reloading");
            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(1f);
            int remainBullet = _bulletCount - _loadCapacity;
            remainBullet -= _loadCapacity;
            if (remainBullet > 0)
            {
                _currentLoad = _loadCapacity;
            }
            else
            {
                _currentLoad = remainBullet;
            }
            Debug.Log(_currentLoad);
            PlayerSignals.Instance.onReloaded?.Invoke(_currentLoad);
        }

        private void CreateBullet()
        {
            --_currentLoad;
            GameObject bullet = PoolSignals.Instance.onGetObject(PoolEnums.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.eulerAngles = transform.eulerAngles;
            bullet.SetActive(true);
        }

        private int GetCurrentLoad()
        {
            return _currentLoad;
        }

        private void OnResetLevel()
        {

        }
    }
}