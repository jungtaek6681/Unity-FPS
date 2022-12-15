using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGFX : MonoBehaviour
{
	private Animator anim;

	[SerializeField]
	private ParticleSystem muzzleFlash;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void Shoot()
	{
		anim.SetTrigger("Shoot");
		muzzleFlash.Play();
	}
}
