using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
	private float deltaX, deltaY;
	private float xRotation = 0;

	[SerializeField]
	private float mouseSensitivity;
	[SerializeField]
	private Transform viewPoint;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		Rotate();
		LookAt();
	}

	private void Rotate()
	{
		deltaX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		transform.Rotate(Vector3.up * deltaX, Space.World);
	}

	private void LookAt()
	{
		deltaY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		// viewPoint.Rotate(Vector3.left * deltaY, Space.Self);	// ī�޶� �������� ��� ������ �ؾ���

		xRotation -= deltaY;	// ���� ����
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		viewPoint.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
	}
}
