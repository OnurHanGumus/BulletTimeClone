using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Extentions;
using Keys;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using Enums;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables


        #endregion

        #region Private Variables

        private int _money;
        [ShowInInspector]
        public int Money
        {
            get { return _money; }
            set { _money = value; }
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
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onScoreIncrease += OnScoreIncrease;
            ScoreSignals.Instance.onScoreDecrease += OnScoreDecrease;
            ScoreSignals.Instance.onGetMoney += OnGetMoney;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onScoreIncrease -= OnScoreIncrease;
            ScoreSignals.Instance.onScoreDecrease -= OnScoreDecrease;
            ScoreSignals.Instance.onGetMoney -= OnGetMoney;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void Start()
        {
            Money = SaveSignals.Instance.onGetScore(SaveLoadStates.Money, SaveFiles.SaveFile);
        }
        private void OnScoreIncrease(ScoreTypeEnums type, int amount)
        {
            Money += amount;
            UISignals.Instance.onSetChangedText?.Invoke(type, Money);
        }

        private void OnScoreDecrease(ScoreTypeEnums type, int amount)
        {
            Money -= amount;
            UISignals.Instance.onSetChangedText?.Invoke(type, Money);
            SaveSignals.Instance.onSaveScore(Money, SaveLoadStates.Money, SaveFiles.SaveFile);
        }


        private int OnGetMoney()
        {
            return Money;
        }

        private void OnNextLevel()
        {
            SaveSignals.Instance.onSaveScore(Money, SaveLoadStates.Money, SaveFiles.SaveFile);
        }

        private void OnRestartLevel()
        {
            
        }
    }
}