using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private AbstractHealthBar healthBarManager;
        #endregion

        #region Private Variables
        private EnemyData _data;
        private bool _isDead = false;
        private int _playerDamage = 0;

        #endregion
        #region Properties
        private int _health = 50;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
            Health = _data.Health;
        }
        public EnemyData GetData() => Resources.Load<CD_Enemy>("Data/CD_Enemy").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EnemySignals.Instance.onGetEnemyCount += OnGetEnemyCount;
            PlayerSignals.Instance.onSendPlayerDamage += OnSendPlayerDamage;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onGetEnemyCount -= OnGetEnemyCount;
            PlayerSignals.Instance.onSendPlayerDamage -= OnSendPlayerDamage;

        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            EnemySignals.Instance.onEnemyArrived?.Invoke();
        }
        public void GetDamage()
        {
            Health -= _playerDamage;
            healthBarManager.SetHealthBarScale(Health);
            if (Health <= 0 && !_isDead)
            {
                _isDead = true;
                EnemyDie();
            }
        }
        private void EnemyDie()
        {
            EnemySignals.Instance.onEnemyDie?.Invoke();
            Destroy(gameObject);
        }

        private int OnGetEnemyCount()
        {
            return 1;
        }

        private void OnSendPlayerDamage(int damage)
        {
            _playerDamage = damage;
        }
        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {

        }
    }
}