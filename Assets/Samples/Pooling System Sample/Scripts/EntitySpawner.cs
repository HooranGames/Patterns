using Hooran._Packages.Pooling;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hooran._Packages.Pooling.Samples
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] int count = 1;

        [SerializeField] GameObject EntityPrefab;

        private void Start()
        {
            SpawnEntity();
        }

        private void SpawnEntity()
        {
            EntityPrefab.Populate(count);

            var entity = EntityPrefab.Reuse<Entity>();

            entity.DoSomething();
        }
    }
}

