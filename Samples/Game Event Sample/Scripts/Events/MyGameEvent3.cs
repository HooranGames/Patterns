using Hooran._Packages.Events.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Events.Samples
{
    [CreateAssetMenu(fileName = "MyGameEvent3", menuName = "Cards/GameEvent/MyGameEvent3", order = 49)]
    public class MyGameEvent3 : SimpleGameEvent<MyGameEvent3>
    {
        protected override bool runOnce => false;
    }

    public partial class GameEventsManager : EventsManagerBase<GameEventsManager>
    {
        public MyGameEvent3 gameEvent3;
    }
}
