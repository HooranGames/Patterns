using Hooran._Packages.Singleton;
using UnityEngine;

namespace Hooran._Packages.Singleton.Samples
{
    public class MyMonoBehaviourSingletonClass : SingletonMonoBehaviour<MyMonoBehaviourSingletonClass>
    {
        public int Counter { get; set; }

        protected override void OnCreateSingleton()
        {
            Debug.Log("On Singleton Created");
            base.OnCreateSingleton();
        }

        protected override void OnDestroySingleton()
        {
            Debug.Log("On Singleton Destroyed");
            base.OnDestroySingleton();
        }
    }
}
