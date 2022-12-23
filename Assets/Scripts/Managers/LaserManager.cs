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
    public class LaserManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private LaserPhysicsController physicsController;
        #endregion

        #region Private Variables
        private LineRenderer _lRenderer;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _lRenderer = GetComponent<LineRenderer>();
        }
        public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EnemySignals.Instance.onEnemyDie += physicsController.OnEnemyDie;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
            PlayerSignals.Instance.onReloading += physicsController.OnReloading;
            PlayerSignals.Instance.onHasReloaded += physicsController.OnHasReloaded;

        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onEnemyDie -= physicsController.OnEnemyDie;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
            PlayerSignals.Instance.onReloading -= physicsController.OnReloading;
            PlayerSignals.Instance.onHasReloaded -= physicsController.OnHasReloaded;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Update()
        {
            DrawLaser();
        }

        private void DrawLaser()
        {
            _lRenderer.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
            {
                if (hit.collider)
                {
                    //bool isSlowMo = hit.collider.CompareTag("Enemy");
                    //PlayerSignals.Instance.onSlowMo?.Invoke(isSlowMo);

                    _lRenderer.SetPosition(1, hit.point);

                }
            }
            else
            {
                _lRenderer.SetPosition(1, transform.forward * 5000);
            }

        }

        private void OnPlay()
        {

        }

        private void OnResetLevel()
        {
            PlayerSignals.Instance.onSlowMo?.Invoke(false);
        }
    }
}