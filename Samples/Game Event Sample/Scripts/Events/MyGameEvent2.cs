using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Events.Samples
{
    [CreateAssetMenu(fileName = "MyGameEvent2", menuName = "Cards/GameEvent/MyGameEvent2", order = 49)]
    public class MyGameEvent2 : GameEvent<string>
    {
        protected override bool runOnce => false;
    }
}
