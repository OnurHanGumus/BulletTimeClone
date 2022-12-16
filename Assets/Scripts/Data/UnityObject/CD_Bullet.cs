using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Bullet", menuName = "Picker3D/CD_Bullet", order = 0)]
    public class CD_Bullet : ScriptableObject
    {
        public BulletData Data;
    }
}