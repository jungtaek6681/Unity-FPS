using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
	private CharacterController controller;
	private float moveY;

	[SerializeField]
	private float gravity = -25;
	[SerializeField]
	private float moveSpeed = 5;
	[SerializeField]
	private float jumpSpeed = 7;

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
	}
	private void Update()
	{
		Move();
		Jump();
	}

	private void Move()
	{
		controller.Move(transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
		controller.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump"))
			moveY = jumpSpeed;
		else if (controller.isGrounded)
			moveY = 0;
		else
			moveY += gravity * Time.deltaTime;

		controller.Move(Vector3.up * moveY * Time.deltaTime);
	}
}
