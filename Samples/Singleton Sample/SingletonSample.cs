using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Singleton.Samples
{
    public class SingletonSample : MonoBehaviour
    {
        private void Start()
        {
            Method1();
            Method2();
        }

        private static void Method1()
        {
            MySingletonClass class1 = MySingletonClass.Instance;
            Debug.Log("Singleton 1 Counter before : " + class1.Counter);
            class1.Counter++;
            Debug.Log("Singleton 1 Counter After : " + class1.Counter);
        }

        private static void Method2()
        {
            MyMonoBehaviourSingletonClass class2 = MyMonoBehaviourSingletonClass.Instance;
            Debug.Log("Singleton 2 Counter before : " + class2.Counter);
            class2.Counter++;
            Debug.Log("Singleton 2 Counter After : " + class2.Counter);
        }
    }
}
