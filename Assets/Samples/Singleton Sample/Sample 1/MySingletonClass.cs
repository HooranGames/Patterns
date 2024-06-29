using Hooran._Packages.Singleton;
using System;

// inherit from Singleton class
namespace Hooran._Packages.Singleton.Samples
{
    public class MySingletonClass : Singleton<MySingletonClass>
    {
        public int Counter { get; set; }

        protected override void OnCreateSingleton()
        {
            Console.WriteLine("On Singleton Created");
            base.OnCreateSingleton();
        }

        protected override void OnDestroySingleton()
        {
            Console.WriteLine("On Singleton Destroyed");
            base.OnDestroySingleton();
        }
    }
}
