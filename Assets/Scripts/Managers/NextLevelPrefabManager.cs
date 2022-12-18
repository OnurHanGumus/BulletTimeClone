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
using TMPro;

namespace Managers
{
    public class NextLevelPrefabManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private SpriteRenderer effect1, effect2;
        [SerializeField] private Color32 readyColor, notReadyColor;
        [SerializeField] private TextMeshPro nextLevelText;
        [SerializeField] private string readyText = "Next Level", notReadyText = "Kill enemies above.";
        [SerializeField] private BoxCollider myCollider;
        [SerializeField]private int enemyCount = 0;

        #endregion

        #region Private Variables
        private PlayerData _data;
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
        public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EnemySignals.Instance.onEnemyDie += OnEnemyDie;
            EnemySignals.Instance.onEnemyArrived += OnEnemyArrived;

        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onEnemyDie -= OnEnemyDie;
            EnemySignals.Instance.onEnemyArrived -= OnEnemyArrived;

        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void Start()
        {
            
        }

        private void OnEnemyArrived()
        {
            enemyCount += EnemySignals.Instance.onGetEnemyCount();
            if (enemyCount > 0)
            {
                CloseTheDoor();
            }
        }

        private void CloseTheDoor()
        {
            effect1.color = notReadyColor;
            effect2.color = notReadyColor;

            nextLevelText.text = notReadyText;
            myCollider.isTrigger = false;
        }
        private void NextLevelOpened()
        {
            effect1.color = readyColor;
            effect2.color = readyColor;

            nextLevelText.text = readyText;
            myCollider.isTrigger = true;
        }
        private void OnEnemyDie()
        {
            --enemyCount;
            if (enemyCount.Equals(0))
            {
                NextLevelOpened();
            }
        }

        
        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {

        }
    }
}