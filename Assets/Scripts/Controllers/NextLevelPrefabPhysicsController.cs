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
    public class NextLevelPrefabPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables


        #endregion

        #region Private Variables
        private bool _isFirstTime = false;
        #endregion
        #region Properties
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
            if (other.CompareTag("Player"))
            {
                if (_isFirstTime)
                {
                    return;
                }
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                AudioSignals.Instance.onPlaySound?.Invoke(SoundEnums.Win);
                _isFirstTime = true;

            }
        }

        

    }
}