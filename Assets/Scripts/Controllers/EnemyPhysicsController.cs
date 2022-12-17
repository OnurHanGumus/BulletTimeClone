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

        [SerializeField] private Rigidbody rig;
        [SerializeField] private BoxCollider col;

        #endregion

        #region Private Variables
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
            
        }

        

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                Health -= 10;
                rig.AddForce(other.attachedRigidbody.velocity, ForceMode.Impulse);
                Debug.Log(Health);
                if (Health <= 0 && !_isDead)
                {
                    _isDead = true;
                    EnemyDie();
                }
            }
        }

        private void EnemyDie()
        {
            PlayerSignals.Instance.onEnemyDie?.Invoke();
            Destroy(transform.parent.gameObject);
        }

    }
}