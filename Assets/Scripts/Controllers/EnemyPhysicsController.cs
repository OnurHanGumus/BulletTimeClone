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
    public class EnemyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyManager manager;

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
            if (other.CompareTag("Bullet"))
            {
                manager.GetDamage();
            }
        }

        

    }
}