using Hooran._Packages.Events.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Events.Samples
{
    public class GameEventInvoker : MonoBehaviour
    {
        // non static refrences 
        [SerializeField] MyGameEvent1 gameEvent1;
        [SerializeField] MyGameEvent2 gameEvent2;

        private void Start()
        {
            InvokeEvents();
        }

        void InvokeEvents()
        {
            gameEvent1.Raise();

            gameEvent2.Raise("Game Event 2 Raised!");

            // static invokes
            MyGameEvent3.Invoke();

            MyGameEvent4.Invoke(1);
        }
    }
}
