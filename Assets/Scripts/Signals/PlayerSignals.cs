using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction<bool> onSlowMo = delegate { };
        public UnityAction onEnemyDie = delegate { };
        public UnityAction<int> onReloaded = delegate { };
    }
}