using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Managers;
using UnityEngine;
using Data.UnityObject;
using Data.ValueObject;
using System;
using Signals;

namespace Controllers
{
    public class LaserPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables



        #endregion

        #region Private Variables
        private bool _isPlayerReloading = false;
        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            
        }

        

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (_isPlayerReloading)
                {
                    return;
                }
                PlayerSignals.Instance.onSlowMo?.Invoke(true);

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                PlayerSignals.Instance.onSlowMo?.Invoke(false);

            }
        }

        public void OnEnemyDie()
        {
            PlayerSignals.Instance.onSlowMo?.Invoke(false);
        }

        public void OnReloading()
        {
            PlayerSignals.Instance.onSlowMo?.Invoke(false);

            _isPlayerReloading = true;
        }

        public void OnHasReloaded(int value, int value2)
        {
            _isPlayerReloading = false;
        }
    }
}