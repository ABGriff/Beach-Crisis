using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float lifeTime = 3.0f;

	private float elapsedTime;

	// Use this for initialization
	void Start ()
	{
		elapsedTime = 0.0f;
	}

	void Update ()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime >= lifeTime)
		{
			Destroy(this.gameObject);
		}
	}
}
