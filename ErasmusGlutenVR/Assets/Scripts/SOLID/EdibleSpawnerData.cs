using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErasmusGluten
{
    [CreateAssetMenu(menuName = "ErasmusGlutenVR/New Food Spawner Data", fileName = "NewFoodSpawnerData.asset")]
    public partial class EdibleSpawnerData : ScriptableObject
    {
        [Header("Gluten objects that can spawn")]
        [SerializeField] public List<EdibleObject> _spawnableGlutenObjects;
        public List<EdibleObject> SpawnableGlutenObjects
        {
            get { return _spawnableGlutenObjects; }
        }

        [Header("Non-gluten objects that can spawn")]
        [SerializeField] public List<EdibleObject> _spawnableNonGlutenObjects;
        public List<EdibleObject> SpawnableNonGlutenObjects
        {
            get { return _spawnableNonGlutenObjects; }
        }

        [Header("Base rethrow time")]
        [SerializeField][Range(1, 5)] int _baseRespawnTime = 3;
        public int BaseRespawnTime
        {
            get { return _baseRespawnTime; }
        }

        [Header("Deviation rethrow time")]
        [SerializeField][Range(1, 5)] int _deviationRespawnTime = 2;
        public int DeviationRespawnTime
        {
            get { return _deviationRespawnTime; }
        }

        [Header("Wait before rethrow time")]
        [SerializeField][Range(0.0f, 1.0f)] float _waitBeforeRespawnTime = 1.0f;
        public float WaitBeforeRespawnTime
        {
            get { return _waitBeforeRespawnTime; }
        }

        [Header("Throw force")]
        [SerializeField][Range(0.1f, 1.0f)] float _throwForce = 0.5f;
        public float ThrowForce
        {
            get { return _throwForce; }
        }

        [Header("Throw direction")]
        [SerializeField] Vector3 _throwDirection = new Vector3(0, 1, -1);
        public Vector3 ThrowDirection
        {
            get { return _throwDirection; }
        }

        [Header("Chance to throw gluten")]
        [SerializeField][Range(0.0f, 1.0f)] float _chanceToSpawnGluten = 0.5f;
        public float ChanceToSpawnGluten
        {
            get { return _chanceToSpawnGluten; }
        }
    }
}
