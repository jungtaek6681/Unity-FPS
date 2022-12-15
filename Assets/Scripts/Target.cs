using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
	[SerializeField]
	private int hp;

	[SerializeField]
	private ParticleSystem destoryEffect;

	public void TakeDamage(int damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			Destroy(gameObject);
			Instantiate(destoryEffect, transform.position, Quaternion.identity);
		}
	}
}
