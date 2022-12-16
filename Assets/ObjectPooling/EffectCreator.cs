using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
	public class EffectCreator : MonoBehaviour
	{
		[SerializeField]
		private EffectDestroyer effectPrefab;

		private void Update()
		{
			if (Input.GetKey(KeyCode.Space))
			{
				Instantiate(effectPrefab, new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)), Quaternion.identity);
			}
		}
	}
}
