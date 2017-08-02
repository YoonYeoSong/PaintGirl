using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
	public float Y_ANGLE_MIN = 5.0f;
	public float Y_ANGLE_MAX = 50.0f;
	public Transform looktAt;
	public Transform camTransform;

	private Camera cam;
	//public float distance = 2.5f; //카메라 와 플레이어 사이 거리.
	public float height = 1.5f; //높이
	public float Width = 4f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 5.0f; //x축 민감도
	private float sensitivityY = 2.5f; //y축 민감도

	JoyStick Joystick = null;

	////카메라 벽통과 X
	private float camera_dist = 0f; //카메라와 플레이어 까지의 거리
	//public float camera_width = -2.5f;
	//public float camera_height = 1.5f;

	Vector3 dir; //카메라, 플레이어까지의 방향벡터
	public static Vector3 cameraRot;
	// Use this for initialization
	void Start ()
	{
		Joystick = GameObject.Find("JoyStick").GetComponent<JoyStick>();
		camTransform = transform;
		cam = Camera.main;

		////플레이어와 카메라 까지의 길이
		camera_dist = Mathf.Sqrt(Width * Width + height * height);
		////플레어어와 카메라위치까지의 방향벡터
		dir = new Vector3(0, height, Width).normalized;
		////looktAt = gameObject.transform.Find("SD_Basic_Change_Main(Clone)").transform;

		if (looktAt == null)
		{
			//looktAt = gameObject.transform.parent.Find("SD_Basic_Change_Main(Clone)").transform;
			looktAt = GameObject.Find("PlayerA").transform;
		}
	}

	// Update is called once per frame
	void Update() {

		if (Joystick.IsPressed != true)
		{
			

			currentX += Input.GetAxis("Mouse X") * sensitivityX;
			currentY += Input.GetAxis("Mouse Y") * (-1) * sensitivityY;

			currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
		}

		


	}

	void LateUpdate()
	{
		Vector3 dir = new Vector3(0, height, Width);


		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		camTransform.position = looktAt.position + rotation * dir;

		cameraRot = camTransform.rotation.eulerAngles;

		camTransform.LookAt(looktAt.position + new Vector3(0, height, 0));



	}
}
