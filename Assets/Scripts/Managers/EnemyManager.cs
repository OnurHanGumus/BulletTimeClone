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
    public class EnemyManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private HealthBarManager healthBarManager;
        #endregion

        #region Private Variables
        private EnemyData _data;
        private bool _isDead = false;

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
        public EnemyData GetData() => Resources.Load<CD_Enemy>("Data/EnemyData").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {

        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        public void GetDamage()
        {
            Health -= 10;
            Debug.Log(Health);
            healthBarManager.SetHealthBarScale(Health);
            if (Health <= 0 && !_isDead)
            {
                _isDead = true;
                EnemyDie();
            }
        }
        private void EnemyDie()
        {
            PlayerSignals.Instance.onEnemyDie?.Invoke();
            Destroy(gameObject);
        }
        private void OnPlay()
        {

        }

        

        private void OnResetLevel()
        {

        }
    }
}