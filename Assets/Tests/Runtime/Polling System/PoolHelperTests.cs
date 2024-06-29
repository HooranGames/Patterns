using UnityEngine;
using NUnit.Framework;

namespace Hooran._Packages.Pooling.Tests
{
    public class PoolHelperTests
    {
        private GameObject _prefab;

        [SetUp]
        public void Setup()
        {
            // Create a prefab for testing
            _prefab = new GameObject();
            _prefab.AddComponent<Poolable>(); // Add Poolable component as required by Pool constructor
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(_prefab);
            _prefab = null;
        }

        [Test]
        public void Reuse_ReturnsComponent()
        {
            // Act
            var component = _prefab.Reuse<Poolable>();

            // Assert
            Assert.IsNotNull(component);
            Assert.IsTrue(component is Poolable);
        }

        // Add more tests as needed for other extension methods
    }
}
