using Hooran._Packages.Events.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Events.Samples
{
    public class GameEventHandler : MonoBehaviour
    {
        // non static refrences 
        [SerializeField] MyGameEvent1 gameEvent1;
        [SerializeField] MyGameEvent2 gameEvent2;

        private void Start()
        {
            gameEvent1.RegisterListener(OnGameEvent1);

            gameEvent2.RegisterListener(OnGameEvent2);

            MyGameEvent3.Register(OnGameEvent3);

            MyGameEvent4.Register(OnGameEvent4);
        }

        private void OnDestroy()
        {
            gameEvent1.UnRegisterListener(OnGameEvent1);

            gameEvent2.UnRegisterListener(OnGameEvent2);
        }

        void OnGameEvent1() => Debug.Log("Game Event 1 Invoked.");
        void OnGameEvent2(string value) => Debug.Log(value);
        void OnGameEvent3() => Debug.Log("Game Event 3 Invoked.");
        void OnGameEvent4(int value) => Debug.Log($"Game Event 4 Invoked : {value}.");
    }
}
