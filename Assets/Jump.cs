using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	//public float speed = 3.0f;
	//public float jumpPower = 5.0f;

	//Rigidbody rigdbody;
	//bool isJumping;

	//private void Awake()
	//{
	//	rigdbody = GetComponent<Rigidbody>();
	//}

	//private void Update()
	//{
	//	if (Input.GetKeyDown(KeyCode.Space))
	//	{
	//		if (transform.position.y >= 0f)
	//		{
	//			isJumping = false;
	//		}
	//		else
	//		{
	//			isJumping = true;
	//		}

	//	}
	//}

	//private void FixedUpdate()
	//{
	//	Jumping();
	//	//isJumping = false;
	//}

	//void Jumping()
	//{
	//	if (!isJumping)
	//		return;

	//	rigdbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
	//	isJumping = false;
	//}


	//public float moveForce = 365f;          // Amount of force added to move the player left and right.
	float maxSpeed = 3.0f;             // The fastest the player can travel in the x axis.
	float jumpForce = 300f;         // Amount of force added when the player jumps.
	private bool grounded = false;
	private bool jump;

	Rigidbody rigdbody;
	// Use this for initialization
	void Start()
	{
		rigdbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		CheckGround(); // 밑이 땅인지 확인
		if (Input.GetButtonDown("Jump") && grounded)
			jump = true;
	}

	//물리 관련 움직임은 이곳에서 처리
	void FixedUpdate()
	{
		//float h = Input.GetAxis("Horizontal");
		//if (h * rigdbody.velocity.x < maxSpeed)
		//{
		//	rigdbody.AddForce(Vector3.right * h * moveForce);
		//}
		////최대 속도보다 크면 최대속도를 조절
		//if (Mathf.Abs(rigdbody.velocity.x) > maxSpeed)
		//{
		//	//속도 조절
		//	//sign -> 값이 양이거나 0 일때 1반환 음의 값이면 -1 반환
		//	rigdbody.velocity = new Vector3(Mathf.Sign(rigdbody.velocity.x) * maxSpeed, rigdbody.velocity.y, rigdbody.velocity.z);
		//}
		if (jump)
		{
			rigdbody.AddForce(new Vector3(0f, jumpForce, 0f));
			jump = false;
		}
	}
	void CheckGround()
	{
		RaycastHit hit;
		Debug.DrawRay(transform.position, Vector3.down * 0.9f, Color.red);

		if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.9f))
		{
			if (hit.transform.tag == "GROUND")
			{
				grounded = true;
				return;
			}
		}
		grounded = false;
	}

}
