using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public static Vector3 cameraRot;
	public float rot_speed = 100.0f;

	public GameObject Player;
	public GameObject MainCamera;
	JoyStick Joystick = null;

	private float camera_dist = 0f; //리그로부터 카메라까지의 거리
	public float camera_width = -4f; //가로거리
	public float camera_height = 1.5f; //세로거리
	public float camera_fix = 0.3f;//레이캐스트 후 리그쪽으로 올 거리
	Vector3 dir;

	public float Y_ANGLE_MIN = -10.0f;
	public float Y_ANGLE_MAX = 50.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 2.0f; //x축 민감도
	private float sensitivityY = 1.5f; //y축 민감도
	void Start()
	{
		Player = GameObject.Find("PlayerA");
		if (Player == null)
			Debug.Log("플레이어 못찾음");
		MainCamera = transform.FindChild("Main Camera").gameObject;

		Joystick = GameObject.Find("JoyStick").GetComponent<JoyStick>();

		//카메라리그에서 카메라까지의 길이
		camera_dist = Mathf.Sqrt(camera_width * camera_width + camera_height * camera_height);

		//카메라리그에서 카메라위치까지의 방향벡터
		dir = new Vector3(0, camera_height, camera_width).normalized;


	}


void Update()
	{

		if (Joystick.IsPressed != true)
		{


			currentX += Input.GetAxis("Mouse X") * sensitivityX;
			currentY += Input.GetAxis("Mouse Y") * (-1) * sensitivityY;

			currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
		}

		//y축 기준 회전
		//transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rot_speed, Space.World);
		//transform.rotation.y = Mathf.Clamp(transform.rotation.y, Y_ANGLE_MIN, Y_ANGLE_MAX);
		currentY += Input.GetAxis("Mouse Y") * (-1) * sensitivityY;

		currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

		//x축 기준 회전
		//transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * rot_speed, Space.Self);
		currentX += Input.GetAxis("Mouse X") * sensitivityX;

		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		transform.rotation = rotation;
		cameraRot = transform.rotation.eulerAngles;

		Vector3 Pos = new Vector3(0,camera_height,camera_width);
		//transform.position = Player.transform.position;
		//transform.position = Pos;

		//transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rot_speed, Space.World);

		//transform.Rotate(Vector3.left * Input.GetAxis("Mouse Y") * Time.deltaTime * rot_speed, Space.Self);

		transform.position = Player.transform.position;


		//레이캐스트할 벡터값
		Vector3 ray_target = transform.up * camera_height + transform.forward * camera_width;

		RaycastHit hitinfo;
		Physics.Raycast(transform.position, ray_target, out hitinfo, camera_dist);

		if (hitinfo.point != Vector3.zero)//레이케스트 성공시
		{
			//point로 옮긴다.
			MainCamera.transform.position = hitinfo.point;
			//MainCamera.transform.Translate(dir * -1 * camera_fix);

		}
		else
		{
			Debug.Log("레이 밖");
			//transform.localPosition = Player.transform.position + rotation * dir;
			//로컬좌표를 0으로 맞춘다. (카메라리그로 옮긴다.)
			MainCamera.transform.localPosition = Pos;
			//카메라위치까지의 방향벡터 * 카메라 최대거리 로 옮긴다.
			//MainCamera.transform.Translate(dir * camera_dist);
			//MainCamera.transform.localPosition = Pos;
			//MainCamera.transform.Translate(dir * -1 * camera_fix);

		}


	}
}



