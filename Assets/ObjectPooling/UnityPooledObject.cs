using ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace ObjectPool
{
	public class UnityPooledObject : MonoBehaviour
	{
		[SerializeField]
		private float returnTime;

		public IObjectPool<UnityPooledObject> poolToReturn;

		private void OnEnable()
		{
			StartCoroutine(DelayToReturn());
		}

		private IEnumerator DelayToReturn()
		{
			yield return new WaitForSeconds(returnTime);
			poolToReturn.Release(this);
		}
	}
}