using Enums;
using Extentions;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class EnemySignals : MonoSingleton<EnemySignals>
    {
        public Func<int> onGetEnemyCount = delegate { return 0; };
        public UnityAction onEnemyDie = delegate { };


    }
}
