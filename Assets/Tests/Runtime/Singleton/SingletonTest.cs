using NUnit.Framework;
using System;
using System.Threading;
using UnityEngine;

namespace Hooran._Packages.Singleton.Tests
{
    public class SingletonTest
    {
        // Example derived singleton class for testing
        private class TestSingleton : Singleton<TestSingleton>
        {
            // Counter to track the number of instances created
            public static int InstanceCount { get; private set; }

            // Constructor to increment the instance counter
            public TestSingleton()
            {
                InstanceCount++;
            }

            // Reset the instance counter for testing
            public static void ResetInstanceCount()
            {
                InstanceCount = 0;
            }

            // Additional initialization logic
            protected override void OnCreateSingleton()
            {
                Debug.Log("TestSingleton created");
            }

            // Additional cleanup logic
            protected override void OnDestroySingleton()
            {
                Debug.Log("TestSingleton destroyed");
            }
        }

        // Setup method to reset state before each test
        [SetUp]
        public void Setup()
        {
            TestSingleton.ResetInstanceCount();
            TestSingleton.Instance.ResetInstance();
        }

        [Test]
        public void Singleton_Instance_IsCreatedOnce()
        {
            // Arrange
            var instance1 = TestSingleton.Instance;
            var instance2 = TestSingleton.Instance;

            // Act & Assert
            Assert.AreEqual(instance1, instance2);
            Assert.AreEqual(1, TestSingleton.InstanceCount);
        }

        [Test]
        public void Singleton_Instance_IsDestroyed()
        {
            // Arrange
            var instance = TestSingleton.Instance;
            instance.DestroyInstance();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => { var newInstance = TestSingleton.Instance; });
        }

        [Test]
        public void Singleton_Instance_ThreadSafety()
        {
            // Arrange
            TestSingleton.ResetInstanceCount();
            TestSingleton.Instance.ResetInstance();

            TestSingleton instance1 = null;
            TestSingleton instance2 = null;

            // Act
            Thread thread1 = new Thread(() => { instance1 = TestSingleton.Instance; });
            Thread thread2 = new Thread(() => { instance2 = TestSingleton.Instance; });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            // Assert
            Assert.AreEqual(instance1, instance2);
            Assert.AreEqual(1, TestSingleton.InstanceCount);
        }

        [Test]
        public void Singleton_ResetInstance()
        {
            // Arrange
            var instance = TestSingleton.Instance;
            instance.DestroyInstance();

            // Act
            TestSingleton.Instance.ResetInstance();
            var newInstance = TestSingleton.Instance;

            // Assert
            Assert.NotNull(newInstance);
            Assert.AreEqual(1, TestSingleton.InstanceCount);
        }
    }
}
