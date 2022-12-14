using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
	private Animator anim;

	[SerializeField]
	private GunGFX gun;

	[SerializeField]
	private int damage;

	[SerializeField]
	private float bulletForce;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

	private void Shoot()
	{
		GameManager.Instance.shootCount++;

		gun.Shoot();
		anim.SetTrigger("Shoot");

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
		{
			IDamagable target = hit.transform.GetComponent<IDamagable>();
			target?.TakeDamage(damage);

			IBulletTakable bulletTakable = hit.transform.GetComponent<IBulletTakable>();
			bulletTakable?.TakeBullet(hit.point, hit.normal, bulletForce);
		}
	}
}
