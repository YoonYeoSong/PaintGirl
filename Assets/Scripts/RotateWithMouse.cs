using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour {

	public Transform target;
	public float speed = 1f;

	Transform mTrans;

	void Start()
	{
		mTrans = transform;
	}

	void OnDrag(Vector2 delta)
	{
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;

		if (target != null)
		{
			target.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * speed, 0f) * target.localRotation;
		}
		else
		{
			GameObject go = GameObject.FindGameObjectWithTag("Player");
			//go.transform.rotation = Quaternion.Euler(0, 180, 0);
			target = go.transform;
			//mTrans.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * speed, 0f) * mTrans.localRotation;
		}
	}

}
