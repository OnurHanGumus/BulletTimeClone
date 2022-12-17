using Data.ValueObject;
using Data.UnityObject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUIController : MonoBehaviour
{
    #region Self Variables

    #region Public Variables


    #endregion

    #region Serialized Variables
    [SerializeField] private Transform playerTransform;

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
    private PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;
    void Start()
    {
        
    }

    public void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
