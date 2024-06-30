using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Hooran._Packages.Pooling.Tests
{
    public class PoolTests
    {
        private GameObject _prefab;
        private Pool _pool;

        [SetUp]
        public void Setup()
        {
            // Create a prefab for testing
            _prefab = new GameObject();
            _prefab.AddComponent<Poolable>(); // Add Poolable component as required by Pool constructor
            _pool = new Pool(_prefab);
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(_prefab);
            _pool.Clear(true); // Clear the pool after each test
        }

        [Test]
        public void Populate_AddsInstancesToPool()
        {
            // Arrange
            int count = 5;

            // Act
            _pool.Populate(count);

            // Assert
            Assert.AreEqual(count, _poolInstanceCount()); // Check the count of instances in the pool
        }

        [Test]
        public void Reuse_ReturnsActiveInstance()
        {
            // Arrange & Act
            var instance = _pool.Reuse();

            // Assert
            Assert.IsTrue(instance.activeSelf);
        }

        [Test]
        public void Release_ReturnsInstanceToPool()
        {
            // Arrange
            var instance = _pool.Reuse();

            // Act
            _pool.Release(instance);

            // Assert
            Assert.IsFalse(instance.activeSelf);
        }

        // Helper method to access private _allInstances list
        private int _poolInstanceCount()
        {
            var allInstancesField = typeof(Pool).GetField("_allInstances", BindingFlags.Instance | BindingFlags.NonPublic);
            var allInstances = (List<GameObject>)allInstancesField.GetValue(_pool);
            return allInstances.Count;
        }
    }
}
