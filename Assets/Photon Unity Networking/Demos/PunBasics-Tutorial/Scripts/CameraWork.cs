// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraWork.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in DemoAnimator to deal with the Camera work to follow the player
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
	/// <summary>
	/// Camera work. Follow a target
	/// </summary>
public class CameraWork : MonoBehaviour
{
	public float Y_ANGLE_MIN = 5.0f;
	public float Y_ANGLE_MAX = 50.0f;
	public Transform looktAt;
	public Transform camTransform;

	private Camera cam;
	public float distance = 2.5f; //카메라 와 플레이어 사이 거리.
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 10.0f; //x축 민감도
	private float sensitivityY = 5.0f; //y축 민감도

	public static Vector3 cameraRot;
	// Use this for initialization
	void Start ()
	{
		camTransform = transform;
		cam = Camera.main;

		//looktAt = gameObject.transform.Find("SD_Basic_Change_Main(Clone)").transform;
	}

	// Update is called once per frame
	void Update () {
		if (looktAt == null)
		{
			//looktAt = gameObject.transform.parent.Find("SD_Basic_Change_Main(Clone)").transform;
			//looktAt = GameObject.Find("SD_Basic_Change_Main 1").transform;
		}

		currentX += Input.GetAxis("Mouse X") * sensitivityX;
		currentY += Input.GetAxis("Mouse Y") * (-1) * sensitivityY;

		currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
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
