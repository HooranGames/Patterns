using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Events.Samples
{
    [CreateAssetMenu(fileName = "MyGameEvent1", menuName = "Cards/GameEvent/MyGameEvent1", order = 49)]
    public class MyGameEvent1 : GameEvent
    {
        protected override bool runOnce => false;
    }
}
