using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemText : MonoBehaviour {

	public AnimationCurve Curve;
	float ShowTime = 1.5f;
	float CurTime = 0.0f;
	float StartY = 0.0f;
	public float XSpeed = 300f;
	public float YSpeed = 300f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = transform.localPosition;
		CurTime += Time.deltaTime;

		pos.y = StartY + Curve.Evaluate(CurTime) * YSpeed;
		transform.localPosition = pos;

		if (CurTime >= ShowTime)
			Destroy(gameObject);
	}
}
