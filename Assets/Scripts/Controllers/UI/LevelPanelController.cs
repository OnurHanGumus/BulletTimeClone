using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Data.UnityObject;
using DG.Tweening;

public class LevelPanelController : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    #endregion
    #region SerializeField Variables
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI levelText;
    #endregion
    #region Private Variables
    private int _levelId = 0;
    private int _moneyCount = 0;

    #endregion
    #endregion
    private void Awake()
    {
        Init();

    }
    private void Init()
    {
    }

    private void Start()
    {
        _levelId = SaveSignals.Instance.onGetScore(SaveLoadStates.Level, SaveFiles.SaveFile);

        _moneyCount = SaveSignals.Instance.onGetScore(SaveLoadStates.Money, SaveFiles.SaveFile);
        InitilizeMoneyText();
        UpdateLevelText();

    }
    private void InitilizeMoneyText()
    {
        moneyText.text = _moneyCount.ToString();

    }
    private void UpdateLevelText()
    {
        levelText.text = "LEVEL " + _levelId.ToString();
    }

    public void OnScoreUpdateText(ScoreTypeEnums type, int score)
    {
        if (type.Equals(ScoreTypeEnums.Money))
        {
            moneyText.text = score.ToString();
        }
    }
    public void OnNextLevel()
    {
        _levelId = LevelSignals.Instance.onGetLevel();
        UpdateLevelText();
    }
    

    public void OnRestartLevel()
    {
       
    }
}
