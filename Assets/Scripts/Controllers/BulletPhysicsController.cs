using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Managers;
using UnityEngine;
using Data.UnityObject;
using Data.ValueObject;
using System;

namespace Controllers
{
    public class BulletPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables



        #endregion

        #region Private Variables
        private BulletData _data;
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

        private BulletData GetData() => Resources.Load<CD_Bullet>("Data/CD_Bullet").Data;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }

    }
}