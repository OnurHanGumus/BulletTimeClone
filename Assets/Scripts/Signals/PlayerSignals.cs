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
        public UnityAction<int,int> onShooted = delegate { };
        public UnityAction onReloading = delegate { };
        public UnityAction<int,int> onHasReloaded = delegate { };
        public UnityAction<int> onSendPlayerDamage = delegate { };
    }
}