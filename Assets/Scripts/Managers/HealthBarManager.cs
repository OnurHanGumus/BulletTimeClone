using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthBarManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables
    public TextMeshPro HealthText;

    #endregion

    #region Serialized Variables
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform healthBar;

    [SerializeField] private GameObject holder;
    #endregion

    #region Private Variables



    #endregion

    #endregion

    #region Event Subscription
    private void OnEnable()
    {
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
    }
    private void UnSubscribeEvent()
    {

    }
    private void OnDisable()
    {
        UnSubscribeEvent();
    }
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
        SetHealthBarScale(50);
    }

    public void SetHealthBarScale(int currentValue, int maxValue = 50)//HealthBar increase or decrease with this method. This method can also listen a signal.
    {
        healthBar.localScale = new Vector3((float)currentValue / maxValue, 1, 1);
        HealthText.text = currentValue.ToString();
    }
}
