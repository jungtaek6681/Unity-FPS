using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool
{
	public class UnityPooler : MonoBehaviour
	{
		private ObjectPool<UnityPooledObject> pool;

		[SerializeField]
		private UnityPooledObject pooledObjectPrefab;

		[SerializeField]
		private int count;

		private void Start()
		{
			pool = new ObjectPool<UnityPooledObject>(
				createFunc: () =>
				{
					var instance = Instantiate(pooledObjectPrefab);
					instance.poolToReturn = pool;
					return instance;
				},
				actionOnGet: (instance) =>
				{
					instance.gameObject.SetActive(true);
				},
				actionOnRelease: (instance) =>
				{
					instance.gameObject.SetActive(false);
					instance.transform.parent = transform;
				},
				actionOnDestroy: (instance) =>
				{
					Destroy(instance.gameObject);
				}, defaultCapacity: 20, maxSize: count);
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.Space))
			{
				Get(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)), Quaternion.identity);
			}
		}

		private UnityPooledObject Get(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			UnityPooledObject instance = pool.Get();
			instance.transform.position = position;
			instance.transform.rotation = rotation;
			instance.transform.parent = parent;
			return instance;
		}
	}
}
