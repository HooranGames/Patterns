using UnityEngine;
using System;

namespace Hooran._Packages.Events
{
    public abstract class SimpleGameEvent<T> : GameEvent where T : SimpleGameEvent<T>
    {
        protected static T EventObject { get; private set; }
        public static bool IsActive => EventObject.isActive;
        public static void Invoke() => EventObject.Raise();
        public static void Register(Action action) => EventObject.RegisterListener(action);
        public static void UnRegister(Action action) => EventObject.UnRegisterListener(action);

        public override void OnAwake()
        {
            EventObject = (T)GameEventsManager.FindEventByType(typeof(T));
        }
    }
    public abstract class GameEvent<T> : GameEventBase
    {
        protected Action<T> listener;
        public override bool hasListener => listener != null;
        public virtual void Raise(T obj)
        {
            if (CanRaise)
                listener?.Invoke(obj);
        }
        public void RegisterListener(Action<T> action)
        {
            listener += action;
        }
        public void UnRegisterListener(Action<T> action)
        {
            listener -= action;
        }
        public override void Clear()
        {
            base.Clear();
            listener = null;
        }
    }
    public abstract class GameEvent : GameEventBase
    {
        protected Action listener;
        public override bool hasListener => listener != null;
        public virtual void Raise()
        {
            if (CanRaise)
                listener?.Invoke();
        }

        public void RegisterListener(Action action)
        {
            listener += action;
        }
        public void UnRegisterListener(Action action)
        {
            listener -= action;
        }
        public override void Clear()
        {
            base.Clear();
            listener = null;
        }

    }
    public abstract class GameEventBase : ScriptableObject
    {
        public virtual int InitOrder { get; private set; } = 0;

        protected bool isActive;
        protected abstract bool runOnce { get; }
        public abstract bool hasListener { get; }
        protected bool CanRaise
        {
            get
            {
                if (!runOnce || !isActive)
                {
                    isActive = true;
                    return true;
                }
                return false;
            }
        }

        public virtual void Clear() => isActive = false;
        public void ResetActivation() => isActive = false;

        public virtual void OnAwake() { }
        public virtual void OnStart() { }
    }
}
