using UnityEngine;
using NUnit.Framework;

// Namespace where your SingletonMonoBehaviour resides
namespace Hooran._Packages.Singleton.Tests
{
    // Test fixture for SingletonMonoBehaviour
    public class SingletonMonoBehaviourTests
    {
        // Mock implementation of SingletonMonoBehaviour for testing
        public class TestSingleton : SingletonMonoBehaviour<TestSingleton>
        {
            // Flag to track if OnDestroySingleton was called
            public bool Destroyed { get; private set; }

            // Override OnDestroySingleton to set the flag
            protected override void OnDestroySingleton()
            {
                base.OnDestroySingleton();
                Destroyed = true;
            }
        }

        // Test case: Ensure SingletonMonoBehaviour initializes correctly
        [Test]
        public void SingletonMonoBehaviour_Initialization()
        {
            // Create a GameObject and attach the SingletonMonoBehaviour
            GameObject testObject = new GameObject("TestObject");
            var singletonComponent = testObject.AddComponent<TestSingleton>();

            // Assert that the SingletonMonoBehaviour instance is not null
            Assert.IsNotNull(TestSingleton.Instance, "Instance of SingletonMonoBehaviour should not be null.");

            // Assert that the SingletonMonoBehaviour instance is the same as the one we created
            Assert.AreEqual(singletonComponent, TestSingleton.Instance, "Instance should be the same as the created component.");
        }

        // Test case: Ensure SingletonMonoBehaviour persists correctly between scenes
        [Test]
        public void SingletonMonoBehaviour_PersistenceOnSceneLoad()
        {
            // Create a GameObject and attach the SingletonMonoBehaviour
            GameObject testObject = new GameObject("TestObject");
            var singletonComponent = testObject.AddComponent<TestSingleton>();

            // Load a new scene (simulate scene change)
            // For Unity Test Framework, use TestContext.LoadScene method
            // TestContext.LoadScene("YourSceneName");

            // Assert that the SingletonMonoBehaviour instance still exists and is the same
            Assert.IsNotNull(TestSingleton.Instance, "Instance of SingletonMonoBehaviour should persist between scenes.");
            Assert.AreEqual(singletonComponent, TestSingleton.Instance, "Instance should persist and be the same.");

            // Clean up after test
            Object.Destroy(testObject);
        }

        // Test case: Ensure OnDestroySingleton is called when object is destroyed
        [Test]
        public void SingletonMonoBehaviour_OnDestroy()
        {
            // Create a GameObject and attach the SingletonMonoBehaviour
            GameObject testObject = new GameObject("TestObject");
            var singletonComponent = testObject.AddComponent<TestSingleton>();

            // Destroy the GameObject
            Object.Destroy(testObject);

            // Assert that OnDestroySingleton was called
            Assert.IsTrue(singletonComponent.Destroyed, "OnDestroySingleton should have been called.");

            // Assert that Instance is null after destruction
            Assert.IsNull(TestSingleton.Instance, "Instance should be null after destruction.");
        }
    }
}
