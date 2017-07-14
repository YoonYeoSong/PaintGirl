using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
	public float Y_ANGLE_MIN = 5.0f;
	public float Y_ANGLE_MAX = 50.0f;
	public Transform looktAt;
	public Transform camTransform;

	private Camera cam;
	public float distance = 2.5f; //카메라 와 플레이어 사이 거리.
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 5.0f; //x축 민감도
	private float sensitivityY = 2.5f; //y축 민감도

	JoyStick Joystick = null;

	public static Vector3 cameraRot;
	// Use this for initialization
	void Start ()
	{
		Joystick = GameObject.Find("JoyStick").GetComponent<JoyStick>();
		camTransform = transform;
		cam = Camera.main;

		//looktAt = gameObject.transform.Find("SD_Basic_Change_Main(Clone)").transform;
	}

	// Update is called once per frame
	void Update() {

		if (Joystick.IsPressed != true)
		{
			if (looktAt == null)
			{
				//looktAt = gameObject.transform.parent.Find("SD_Basic_Change_Main(Clone)").transform;
				looktAt = GameObject.Find("PlayerA").transform;
			}

			currentX += Input.GetAxis("Mouse X") * sensitivityX;
			currentY += Input.GetAxis("Mouse Y") * (-1) * sensitivityY;

			currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
		}
		
	}
	
	void LateUpdate()
	{
		Vector3 dir = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		camTransform.position = looktAt.position + rotation * dir;

		cameraRot = camTransform.rotation.eulerAngles;

		camTransform.LookAt(looktAt.position + new Vector3(0, 1.2f, 0));
	}
}
