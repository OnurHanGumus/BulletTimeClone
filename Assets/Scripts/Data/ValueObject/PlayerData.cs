using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public float Speed = 5;
        public float ForceX = 5, ForceY;
        public float Health = 100;
        public float InitializePosX = 0, InitializePosY = 0;
        public int DefaultDamage = 10;

        public int DamageIncreaseValue = 2, BulletIncreaseValue = 2;
        public float ReloadTimeDecreaseValue = 0.2f;

        public int TotalBulletCount = 51, CurrentBulletCount = 17;

    }
}