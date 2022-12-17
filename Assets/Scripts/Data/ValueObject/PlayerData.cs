using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public float Speed = 5;
        public float ForceX = 5, ForceY;
        public float HealthBarPosY = 0.5f;
        public float Health = 100;

    }
}