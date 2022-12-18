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
                RiseToScorePanel();
            }
        }

        private void RiseToScorePanel()
        {
            var pos = new Vector3(1006, 1893, 5);
            //transform.position = Camera.main.ScreenToWorldPoint(pos);
            transform.parent.DOMove(Camera.main.ScreenToWorldPoint(pos), 1f);
        }

       



    }
}