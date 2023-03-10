using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.ValueObject;
using Data.UnityObject;
public class EnemyHealthBarController : AbstractHealthBar
{
    #region Self Variables

    #region Public Variables


    #endregion

    #region Serialized Variables
    [SerializeField] private Transform playerTransform;

    #endregion

    #region Private Variables
    private EnemyData _data;

    #endregion

    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _data = GetData();
        base.SetHealthBarScale((int)_data.Health, (int)_data.Health);
    }
    private EnemyData GetData() => Resources.Load<CD_Enemy>("Data/CD_Enemy").Data;


    public override void Start()
    {
        
    }

    public override void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + _data.HealthBarPosY, transform.position.z);
    }
}
