using Hooran._Packages.Events.Samples;
using Hooran._Packages.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Hooran._Packages.Events.Samples
{
    [CreateAssetMenu(fileName = "MyGameEvent4", menuName = "Cards/GameEvent/MyGameEvent4", order = 49)]
    public class MyGameEvent4 : GameEvent<int>
    {
        public static MyGameEvent4 Instance { get; private set; }

        protected override bool runOnce => false;

        public static void Invoke(int value) => Instance.Raise(value);
        public static void Register(Action<int> action) => Instance.RegisterListener(action);
        public static void UnRegister(Action<int> action) => Instance.UnRegisterListener(action);

        public override void OnAwake()
        {
            Instance = (MyGameEvent4)GameEventsManager.FindEventByType(typeof(MyGameEvent4));

            base.OnAwake();
        }
    }

    public partial class GameEventsManager : EventsManagerBase<GameEventsManager>
    {
        public MyGameEvent4 gameEvent4;
    }
}
