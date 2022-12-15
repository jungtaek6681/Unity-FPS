using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBall : MonoBehaviour, IBulletTakable
{
	private Rigidbody rigid;

	[SerializeField]
	private ParticleSystem bulletEffect;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody>();
	}

	public void TakeBullet(Vector3 hitPoint, Vector3 hitNormal, float hitForce)
	{
		ParticleSystem particle = Instantiate(bulletEffect, hitPoint, Quaternion.LookRotation(hitNormal));
		particle.transform.parent = transform;

		rigid?.AddForce(-hitNormal * hitForce, ForceMode.Impulse);
	}
}
