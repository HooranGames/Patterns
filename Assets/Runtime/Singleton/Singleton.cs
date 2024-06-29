using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Singleton
{
    /// <summary>
    /// Inherit from this base class to create a Singleton.
    /// e.g. public class MyClassName : Singleton<MyClassName> {}
    /// </summary>
    public class Singleton<T> where T : class, new()
    {
        // Static instance of the singleton
        private static T instance;

        // Lock object for thread safety
        private static readonly object lockObject = new object();

        // Flag to check if the singleton instance has been destroyed
        private static bool isDestroyed = false;

        // Protected constructor to prevent instantiation from outside
        protected Singleton()
        {
            if (instance != null)
            {
                // Throws an exception if an instance already exists
                throw new InvalidOperationException("An instance of this singleton already exists.");
            }
        }

        // Public static property to get the singleton instance
        public static T Instance
        {
            get
            {
                // Return null if in the editor and not playing
                if (Application.isEditor && !Application.isPlaying)
                    return null;

                // Throws an exception if the singleton instance has been destroyed
                if (isDestroyed)
                {
                    throw new InvalidOperationException($"Instance of {typeof(T)} has already been destroyed.");
                }

                // Ensures thread safety while creating the instance
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        // Creates a new instance of the singleton
                        instance = new T();

                        // Calls OnCreateSingleton if it is implemented
                        (instance as Singleton<T>)?.OnCreateSingleton();
                    }
                }

                // Returns the singleton instance
                return instance;
            }
        }

        // Virtual method that can be overridden in derived classes to handle additional initialization
        protected virtual void OnCreateSingleton()
        {
        }

        // Virtual method that can be overridden in derived classes to handle additional cleanup
        protected virtual void OnDestroySingleton()
        {
        }

        // Method to destroy the singleton instance
        public void DestroyInstance()
        {
            // Ensures thread safety while destroying the instance
            lock (lockObject)
            {
                if (instance != null)
                {
                    // Calls OnDestroySingleton if it is implemented
                    OnDestroySingleton();

                    // Disposes the instance if it implements IDisposable
                    if (instance is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                    instance = null; // Sets the instance to null
                    isDestroyed = true; // Sets the destruction flag
                }
            }
        }

        // Example method to reset the destruction flag (useful for unit tests or restarting the game)
        public void ResetInstance()
        {
            // Ensures thread safety while resetting the destruction flag
            lock (lockObject)
            {
                isDestroyed = false;
            }
        }
    }
}
