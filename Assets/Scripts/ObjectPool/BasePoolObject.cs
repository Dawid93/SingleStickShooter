using UnityEngine;

namespace ObjectPool
{
    public abstract class BasePoolObject : MonoBehaviour
    {
        public string PoolTag { get; private set; }
        private ObjectPooler objectPooler;

        public virtual void OnCreate(string poolTag, ObjectPooler objectPooler)
        {
            PoolTag = poolTag;
            this.objectPooler = objectPooler;
        }

        public abstract void OnSpawn();
        public abstract void OnReturn();

        public void SelfReturn()
        {
            objectPooler.ReturnToPool(this);
        }
    }
}
