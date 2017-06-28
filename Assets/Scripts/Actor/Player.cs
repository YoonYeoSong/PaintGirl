using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Actor
{

	Animator Anim;

	JoyStick Stick;

	DetectionArea DetectArea;


	eStateType State;// = eStateType.STATE_IDLE;

	//Rigidbody rigi;
	float AttackRange = 3.0f;
	public float speed = 3.0f;
	public float jumpPower = 5.0f;

	Rigidbody rigdbody;
	bool isJumping;

	void Start()
	{
		IS_PLAYER = true;
		Anim = this.GetComponentInChildren<Animator>();
		Stick = JoyStick.Instance;
		rigdbody = GetComponent<Rigidbody>();

		DetectArea = SelfObject.GetComponentInChildren<DetectionArea>();
		if (DetectArea == null)
		{
			Debug.Log("DetectionArea가 없어서 생성.");
			GameObject go = new GameObject(typeof(DetectionArea).ToString(), typeof(DetectionArea));

			go.transform.SetParent(SelfTransform);
			go.transform.localPosition = Vector3.zero;
			DetectArea = go.GetComponent<DetectionArea>();
		}
		DetectArea.Inin(this, this.AttackRange);

		State = eStateType.STATE_IDLE;
	}

	protected override void Update()
	{


		CheckGround(); // 밑이 땅인지 확인


		if (Input.GetKeyDown(KeyCode.F1))
		{
			Vector2 Axis = Stick.Axis;
			Vector3 MovePosition = new Vector3(0, 0, 0);
			MovePosition += new Vector3(Axis.x, 0, Axis.y + 50f);
			SelfTransform.position += (this.transform.rotation * Quaternion.Euler(1.0f, 0.0f, 1.0f)) * MovePosition * Time.deltaTime * 2;
		}
		else if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			State = eStateType.STATE_JUMP;
			SetAnimation(State);
			jump = true;
			//isJumping = true;
		}
		else if (Stick.IsPressed)
		{

			Vector2 Axis = Stick.Axis;
			Vector3 MovePosition = new Vector3(0, 0, 0);
			Vector3 MoveRotation = new Vector3(0, 0, 0);
			Vector3 Rot = Vector3.zero;


			MovePosition += new Vector3(Axis.x, 0, Axis.y);


			SelfTransform.position += (this.transform.rotation * Quaternion.Euler(1.0f, 0.0f, 1.0f)) * MovePosition * Time.deltaTime * 2;
			SelfTransform.rotation = Quaternion.Euler(ThirdPersonCamera.cameraRot);

			//SelfTransform.rotation = Quaternion.LookRotation(ThirdPersonCamera.cameraRot);
			//Quaternion newRotation = Quaternion.LookRotation(SelfTransform.position);
			//rigi.rotation = Quaternion.Slerp(rigi.rotation, newRotation, 10.0f * Time.deltaTime);
			//this.SelfComponent<NavMeshAgent>().SetDestination(MovePosition);
			//AI.ClearAI();
			//Agent.Resume();
			//Agent.SetDestination(MovePosition);

			if(isJumping == true)
			{
				print(State);
				return;
			}else
			{
				State = eStateType.STATE_WALK;
				SetAnimation(State);
			}
		}
		else if(!Stick.IsPressed)
		{
			SelfTransform.rotation = Quaternion.Euler(ThirdPersonCamera.cameraRot);

			if (isJumping == true)
			{
				print(State);
				return;
			}
			else
			{
				State = eStateType.STATE_IDLE;
				SetAnimation(State);
			}
		}
	}

	public void SetAnimation(eStateType state)
	{
		Anim.SetInteger("State", (int)state);	
	}

	//public override void ThrowEvent(string keyData, params object[] datas)
	//{
	//	switch (keyData)
	//	{
	//		case "AttackEnd":
	//			{
	//				//SetAnimation((eStateType)datas[0]);
	//			}
	//			break;
	//		default:
	//			{
	//				base.ThrowEvent(keyData, datas);
	//			}
	//			break;
	//	}
	//}

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

	public float moveForce = 365f;          // Amount of force added to move the player left and right.
	float maxSpeed = 3.0f;             // The fastest the player can travel in the x axis.
	float jumpForce = 300f;         // Amount of force added when the player jumps.
	private bool grounded = false;
	private bool jump;

	//물리 관련 움직임은 이곳에서 처리
	void FixedUpdate()
	{
		if (jump)
		{
			rigdbody.AddForce(new Vector3(0f, jumpForce, 0f));
			jump = false;
		}
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
			print(isJumping);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.transform.tag == "GROUND")
		{
			isJumping = true;
			print(isJumping);
		}
	}

}
