using System.Collections;
using UnityEngine;

public class UnityPhysics : MonoBehaviour
{
	public Rigidbody body;
	bool go = false;
	float peak = 0.0f;

	IEnumerator Start()
	{
		yield return new WaitForSeconds(1.0f);
		go = true;
		float force = Mathf.Sqrt(-2.0f * Physics.gravity.y * 10.0f * body.mass);
		body.AddForce(Vector3.up * force, ForceMode.Impulse);
	}

	void FixedUpdate()
	{
		if (go)
		{
			Debug.Log($"{name} {Time.time}s {body.position.y}m", gameObject);
			if (peak < body.position.y - 0.5f)
			{
				peak = body.position.y - 0.5f;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (go)
		{
			Debug.Log($"{name} hits peak of {peak}m", gameObject);
			go = false;
		}
	}
}
