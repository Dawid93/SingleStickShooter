using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPooler : MonoBehaviour, IInitializable
    {
        public static ObjectPooler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ObjectPooler>();
                return _instance;
            }
        }
        private static ObjectPooler _instance;
        
        [SerializeField] private Vector3 spawnPos;
        [SerializeField] private PoolContainer poolContainer;
        [SerializeField] private int increasePoolValue = 10;
        [SerializeField] private int minCountToIncreasePool = 2;

        private Dictionary<string, Queue<BasePoolObject>> _poolDict;
        private bool _poolIsInit;
        private void Awake()
        {
            if (_instance == null)
                _instance = this;
        }
        
        public void Initialize()
        {
            InitPools();
        }

        private void InitPools()
        {
            if (!poolContainer)
            {
                Debug.LogError("[ObjectPooler] PoolContainer is missing");
                return;
            }
            if(_poolIsInit || !poolContainer)
                return;
            
            _poolDict = new Dictionary<string, Queue<BasePoolObject>>();

            foreach (var pool in poolContainer.Pools)
            {
                Queue<BasePoolObject> poolObjectsQ = new Queue<BasePoolObject>();
                
                AddObjectsToPool(pool.PoolTag, pool.PoolObject, poolObjectsQ, pool.PoolSize);
                
                _poolDict.Add(pool.PoolTag, poolObjectsQ);
            }

            _poolIsInit = true;
        }

        private void AddObjectsToPool(string poolTag, BasePoolObject poolObject, Queue<BasePoolObject> poolObjectsQueue,
            int amount)
        {
            for (int i = 0; i < amount; i++)
                AddObjectToPool(poolTag, poolObject, poolObjectsQueue);
        }

        private void AddObjectToPool(string poolTag, BasePoolObject poolObject, Queue<BasePoolObject> poolObjectsQueue)
        {
            BasePoolObject bpo = Instantiate(poolObject, spawnPos, Quaternion.identity); 
            bpo.OnCreate(poolTag, this);
            bpo.gameObject.SetActive(false);
            poolObjectsQueue.Enqueue(bpo);
        }

        public BasePoolObject GetFromPool(string poolTag, Vector3 pos, Quaternion rot, Transform parent)
        {
            if (!_poolIsInit)
                InitPools();
            if (_poolDict == null)
                return null;
            if (!_poolDict.ContainsKey(poolTag))
                return null;

            if(_poolDict[poolTag].Count <= minCountToIncreasePool)
                IncreasePool(poolTag);
            
            BasePoolObject poolObject = _poolDict[poolTag].Dequeue();
            Transform poolTransform = poolObject.transform;
            
            poolTransform.SetParent(parent);
            poolTransform.localPosition = pos;
            poolTransform.localRotation = rot;
            poolObject.gameObject.SetActive(true);
            poolObject.OnSpawn();
            return poolObject;
        }

        private void IncreasePool(string poolTag)
        {
            var pool = GetPoolWithPoolTag(poolTag);
            AddObjectsToPool(poolTag, pool.PoolObject, _poolDict[poolTag], increasePoolValue);
        }

        private Pool GetPoolWithPoolTag(string poolTag)
        {
            return poolContainer.Pools.First(x => x.PoolTag == poolTag);
        }

        public void ReturnToPool(BasePoolObject basePoolObject)
        {
            basePoolObject.OnReturn();
            Transform poolTransform = basePoolObject.transform;
            poolTransform.SetParent(null);
            poolTransform.position = spawnPos;
            basePoolObject.gameObject.SetActive(false);
            _poolDict[basePoolObject.PoolTag].Enqueue(basePoolObject);
        }
    }
}
