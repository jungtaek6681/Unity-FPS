using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
	[SerializeField]
	private Animator gunAnim;
	[SerializeField]
	private Animator playerAnim;

	[SerializeField]
	private int damage;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

	private void Shoot()
	{
		gunAnim.SetTrigger("Shoot");
		playerAnim.SetTrigger("Shoot");

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
		{
			IDamagable target = hit.transform.GetComponent<IDamagable>();
			target?.TakeDamage(damage);
		}
	}
}
