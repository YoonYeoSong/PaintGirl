using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Actor
{

	Animator Anim;

	JoyStick Stick;

	DetectionArea DetectArea;


	eStateType State;

	//Rigidbody rigi;
	float AttackRange = 3.0f;
	public float speed = 3.0f;
	public float jumpPower = 5.0f;

	Rigidbody rigdbody;
	bool isJumping;
	bool isRoll;

	float ftime;
	public float moveForce = 365f;          // Amount of force added to move the player left and right.
	float maxSpeed = 3.0f;             // The fastest the player can travel in the x axis.
	float jumpForce = 300f;         // Amount of force added when the player jumps.
	private bool grounded = false;
	private bool jump;


	void Start()
	{
		isJumping = false;
		isRoll = false;
		IS_PLAYER = true;
		Stick = JoyStick.Instance;
		rigdbody = GetComponent<Rigidbody>();
			
		Anim = this.GetComponentInChildren<Animator>();
		State = eStateType.STATE_IDLE;
		SetAnimation(State);
	}

	protected override void Update()
	{



		CheckGround(); // 밑이 땅인지 확인
	
		if (Input.GetKeyDown(KeyCode.Space) && grounded) // 점프
		{
			State = eStateType.STATE_JUMP;
			SetAnimation(State);
			jump = true;
		}
		else if (Input.GetKeyDown(KeyCode.F1)) // 구르기
		{
			isRoll = true;
			State = eStateType.STATE_ROLL;
			SetAnimation(State);
		}
		else if(!Stick.IsPressed) // 눌리지 않았을때
		{
			if (isJumping == true)
			{
				return;
			}
			else
			{
				if (isRoll == false)
				{
					State = eStateType.STATE_IDLE;
					SetAnimation(State);
				}
				else
					return;
				//State = eStateType.STATE_IDLE;
				//SetAnimation(State);
			}
		}
		else if (Stick.IsPressed)  // 눌 렸을때
		{

			if (isJumping == true)
			{
				return;
			}
			else
			{
				if(isRoll == false)
				{
					State = eStateType.STATE_WALK;
					SetAnimation(State);
				}
				else
					return;
				//State = eStateType.STATE_WALK;
				//SetAnimation(State);
			}
		}
	}

	public void SetAnimation(eStateType state)
	{
		Anim.SetInteger("State", (int)state);
	}

	private void OnEnable()
	{
		StartCoroutine("FSMMain"); // fsm
	}

	IEnumerator FSMMain()
	{
		while(true)
		{
			yield return StartCoroutine(State.ToString());
		}
	}

	IEnumerator STATE_IDLE()
	{
		// Enter

		while (State == eStateType.STATE_IDLE)
		{	
			yield return null;
			// Excute
		}

		// Exit
	}

	IEnumerator STATE_WALK()
	{
		// Enter
		while (State == eStateType.STATE_WALK)
		{
			yield return null;
			// Excute
		}
		// Exit
	}

	IEnumerator STATE_ATTACK()
	{
		// Enter
		while (State == eStateType.STATE_ATTACK)
		{
			yield return null;
			// Excute
		}
		// Exit
	}
	IEnumerator STATE_JUMP()
	{
		// Enter
		while (State == eStateType.STATE_JUMP)
		{
			yield return null;
			// Excute
		}
		// Exit
	}
	IEnumerator STATE_DEAD()
	{
		// Enter
		while (State == eStateType.STATE_DEAD)
		{
			yield return null;
			// Excute
		}
		// Exit
	}

	IEnumerator STATE_ROLL()
		
	{
		// Enter
		while (State == eStateType.STATE_ROLL)
		{
			yield return null;
			// Excute
		}
		// Exit
	}


	//물리 관련 움직임은 이곳에서 처리
	
	void FixedUpdate()
	{
		if (Stick.IsPressed)
		{

			Vector2 Axis = Stick.Axis;
			Vector3 MovePosition = new Vector3(0, 0, 0);
			Vector3 MoveRotation = new Vector3(0, 0, 0);
			Vector3 Rot = Vector3.zero;
			MovePosition += new Vector3(Axis.x, 0, Axis.y);
			SelfTransform.position += (this.transform.rotation * Quaternion.Euler(1.0f, 0.0f, 1.0f)) * MovePosition * Time.deltaTime * 2;
			SelfTransform.rotation = Quaternion.Euler(ThirdPersonCamera.cameraRot);
			//if (isJumping == true)
			//{
			//	return;
			//}
			//else
			//{
			//	if (isRoll == false)
			//	{
			//		State = eStateType.STATE_WALK;
			//		SetAnimation(State);
			//	}
			//	//State = eStateType.STATE_WALK;
			//	//SetAnimation(State);
			//}
			//SelfTransform.rotation = Quaternion.LookRotation(ThirdPersonCamera.cameraRot);
			//Quaternion newRotation = Quaternion.LookRotation(SelfTransform.position);
		}
		else
		{
			isJumping = false;
			isRoll = false;
			//State = eStateType.STATE_IDLE;
			//SetAnimation(State);
			SelfTransform.rotation = Quaternion.Euler(ThirdPersonCamera.cameraRot);
		}

		if (isRoll)
		{
			ftime += Time.deltaTime;
			Vector2 Axis = Stick.Axis;
			Vector3 MovePosition = new Vector3(0, 0, 0);
			MovePosition += new Vector3(Axis.x, 0, Axis.y + 1f);
			SelfTransform.position += (this.transform.rotation * Quaternion.Euler(1.0f, 0.0f, 1.0f)) * MovePosition * Time.deltaTime * 1.0f;
		}
		//else
		//{
		//	//if(isJumping == false  && isRoll == false || Stick.IsPressed == true)
		//	//{
		//	//	State = eStateType.STATE_WALK;
		//	//	SetAnimation(State);
		//	//}
		//	//else if(isJumping == false && isRoll == false || Stick.IsPressed == false)
		//	//{
		//	//	State = eStateType.STATE_IDLE;
		//	//	SetAnimation(State);
		//	//}
		//}

		if (jump)
		{
			rigdbody.AddForce(new Vector3(0f, jumpForce, 0f));
			jump = false;
		}

		if (ftime >= 0.4f)
		{
			State = eStateType.STATE_IDLE;
			SetAnimation(State);
			isRoll = false;
			ftime = 0;
			

			return;
		}

		//if (isRoll == false)
		//{
		//	if (Stick.IsPressed)
		//	{
		//		State = eStateType.STATE_WALK;
		//		SetAnimation(State);
		//	}
		//	else
		//	{
		//		if (isJumping == true)
		//		{
		//			return;
		//		}
		//		else
		//		{
		//			State = eStateType.STATE_IDLE;
		//			SetAnimation(State);
		//		}
		//	}
		//}

	}

	void CheckGround()
	{
		RaycastHit hit;
		Debug.DrawRay(transform.position, new Vector3(0, -1f, 0) * 0.9f, Color.red);

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

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "GROUND")
		{
			isJumping = false;
			
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.transform.tag == "GROUND")
		{
			isJumping = true;
			
		}
	}

}
