using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
	public class EffectDestroyer : MonoBehaviour
	{
		[SerializeField]
		private float destroyTime;

		private void Start()
		{
			StartCoroutine(DelayToReturn());
		}

		private IEnumerator DelayToReturn()
		{
			yield return new WaitForSeconds(destroyTime);
			Destroy(gameObject);
		}
	}
}
