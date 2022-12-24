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
    public class MoneyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables


        #endregion

        #region Private Variables
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
                ScoreSignals.Instance.onScoreIncrease?.Invoke(ScoreTypeEnums.Money, 10);
                transform.parent.gameObject.SetActive(false);
                AudioSignals.Instance.onPlaySound?.Invoke(SoundEnums.Collect);
            }
        }

       



    }
}