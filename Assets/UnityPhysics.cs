using System.Collections;
using UnityEngine;

public class UnityPhysics : MonoBehaviour
{
	public Rigidbody body;
	public bool corrected = false;
	bool go = false;
	bool impulse = false;
	float height;
	float peak = 0.0f;

	float JumpVelocity(float height)
	{
		return Mathf.Sqrt(-2.0f * Physics.gravity.y * height);
	}

	IEnumerator Start()
	{
		height = TestParameters.height;
		yield return new WaitForSeconds(1.0f);
		go = true;
		impulse = true;
	}

	void FixedUpdate()
	{
		if (go)
		{
			//Debug.Log($"{name} {Time.time}s {body.position.y}m", gameObject);
		}

		if (peak < body.position.y - 0.5f)
		{
			peak = body.position.y - 0.5f;
		}

		if (impulse)
		{
			float v = JumpVelocity(height);
			if (corrected)
			{
				float bodge = -0.5f * Physics.gravity.y * Time.fixedDeltaTime;
				v += bodge;
			}

			float force = v * body.mass;
			body.AddForce(Vector3.up * force, ForceMode.Impulse);
			impulse = false;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (go)
		{
			Debug.Log($"{name} short by {(height - peak)*100f:G2}cm", gameObject);
			go = false;
		}
	}
}
