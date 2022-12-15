using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletTakable
{
	void TakeBullet(Vector3 hitPoint, Vector3 hitNormal, float hitForce);
}
