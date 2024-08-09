using System.Collections;
using UnityEngine;

public class ManualSuvat : MonoBehaviour
{
	public Rigidbody body;
	bool go = false;
	float u = 0.0f;
	float peak = 0.0f;
	float height;


	IEnumerator Start()
	{
		height = TestParameters.height;
		yield return new WaitForSeconds(1.0f);
		go = true;
		u = Mathf.Sqrt(-2.0f * Physics.gravity.y * height);
	}

	void FixedUpdate()
	{
		if (go)
		{
			//Debug.Log($"{name} {Time.time}s {body.position.y}m", gameObject);
			float dt = Time.fixedDeltaTime;
			float s;
			float a = Physics.gravity.y;
			float v = u + a * dt;
			// s = ut + ½at²
			s = u * dt + 0.5f * a * dt * dt;
			body.position = body.position + Vector3.up * s;
			u = v;
			if (peak < body.position.y - 0.5f)
			{
				peak = body.position.y - 0.5f;
			}

			if (body.position.y < 0.5f)
			{
				Vector3 position = body.position;
				position.y = 0.5f;
				body.position = position;
				Debug.Log($"{name} short by {(height - peak)*100f:G2}cm", gameObject);
				go = false;
			}
		}
	}
}
