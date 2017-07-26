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
	public string m1;
	Rigidbody rigdbody;
	bool isJumping;
	bool isRoll;

	float ftime;
	public float moveForce = 365f;          // Amount of force added to move the player left and right.
	float maxSpeed = 3.0f;             // The fastest the player can travel in the x axis.
	float jumpForce = 300f;         // Amount of force added when the player jumps.
	private bool grounded = false;
	private bool jump;
	public float AddSpeed = 0.0f;
	public bool MoveSpeedUpItem = false;
	public bool MoveSpeedDownItem = false;
	public bool StunItem = false;

	int m_iTeamCheck = 0; // A팀 스크립트인지 B팀 스크립트인지 구분

	float MoveSpeedUpItemTime = 0.0f;			//시간관련
	float MoveSpeedDownItemTime = 0.0f;
	public float StunItemTime = 0.0f;
	float StubFadeOutTime = 4.0f;
	float ItemEffectFadeOutTime = 10.0f;

	GameObject BPlayer = null;//.GetComponent<Player>();
	
	void Start()
	{

		BPlayer = GameObject.Find("PlayerB");
		isJumping = false;
		isRoll = false;
		//IS_PLAYER = true;
		Stick = JoyStick.Instance;
		rigdbody = GetComponent<Rigidbody>();
			
		Anim = this.GetComponentInChildren<Animator>();
		State = eStateType.STATE_IDLE;
		SetAnimation(State);
	}

	 void Update()
	{
		MoveSpeedUpItemTime += Time.deltaTime;
		MoveSpeedDownItemTime += Time.deltaTime;
		StunItemTime += Time.deltaTime;

		
			if (MoveSpeedUpItem == true)
				if (ItemEffectFadeOutTime <= MoveSpeedUpItemTime)
				{
					MoveSpeedUpItem = false;
					Debug.Log("버프끝");
					
				}

			if (MoveSpeedDownItem == true)
				if (ItemEffectFadeOutTime <= MoveSpeedDownItemTime)
				{
					MoveSpeedDownItem = false;
					Debug.Log("버프끝");
				}

		if (StunItem == true)
		{
			if (StubFadeOutTime <= StunItemTime)
			{
				StunItem = false;

				//if (m_iTeamCheck == 1)
				//PlayerA.transform.localScale = Vector3.one;

				//if (m_iTeamCheck == 2)
				//PlayerB.transform.localScale = Vector3.one;
				transform.localScale = Vector3.one;
				Debug.Log("스턴 끝");
			}
		}

		m_iTeamCheck = 0;

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

	//private void OnEnable()
	//{
	//	StartCoroutine("FSMMain"); // fsm
	//}

	//IEnumerator FSMMain()
	//{
	//	while(true)
	//	{
	//		yield return StartCoroutine(State.ToString());
	//	}
	//}

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
			//if(Axis.x != 0 && Axis.y ==0)
			if(MoveSpeedUpItem == true)
				MovePosition += new Vector3(Axis.x * 2, 0, Axis.y * 2);
			else
				MovePosition += new Vector3(Axis.x, 0, Axis.y);

			if (MoveSpeedDownItem == true)
				MovePosition += new Vector3(Axis.x / 4, 0, Axis.y / 4);
			else
				MovePosition += new Vector3(Axis.x, 0, Axis.y);

			if (StunItem == true)
			{

				MovePosition = new Vector3(Axis.x *0, 0, Axis.y * 0);//Axis.x * 0, 0, Axis.y * 0);
				Debug.Log("스턴중이다!");
				GameObject temp = Resources.Load("Prefabs/Game/UI/Stun") as GameObject;
				Instantiate(temp);
			}
			else
				MovePosition += new Vector3(Axis.x, 0, Axis.y);
			

			//if(Axis.y != 0)
			//	MovePosition += new Vector3(Axis.x , 0, Axis.y + AddSpeed);
			//MovePosition += new Vector3(Axis.x+AddSpeed, 0, Axis.y+AddSpeed );
			//Debug.Log("Movepostion : " + MovePosition + ", AddSpeed : "+ AddSpeed);

			SelfTransform.position += (this.transform.rotation * Quaternion.Euler(1.0f, 0.0f, 1.0f)) * MovePosition * Time.deltaTime * 2;
			//SelfTransform.position += new Vector3(0.2f, 0, 0.2f);//new Vector3(AddSpeed, 0, AddSpeed);
			SelfTransform.rotation = Quaternion.Euler(CameraMove.cameraRot);
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
			SelfTransform.rotation = Quaternion.Euler(CameraMove.cameraRot);
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
		if (collision.transform.tag == "GROUND" || collision.transform.tag == "Coll")
		{
			isJumping = false;
			
		}
		if (collision.transform.tag == "APlayer")
			Debug.Log("피격!");
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.transform.tag == "GROUND" || collision.transform.tag == "Coll")
		{
			isJumping = true;
			
		}

		if (collision.transform.tag == "APlayer")
			Debug.Log("피격!");
	}

	//private void OnParticleCollision(GameObject other)
	//{
	//	m1 = other.tag;
	//	if(other.transform.tag == "APlayer")
	//		Debug.Log("피격!");
	//}


	public void Buff()
	{
		
		ItemType();
	}




	void ItemType()
	{
		int type = -1;
		type = Random.Range(0, 2);
		if (type == 0)
			PositiveItem();

		else if (type == 1)
			NegativeItem();
	}

	void PositiveItem()
	{
		int type = -1;
		type = Random.Range(0, 2);
		if (type == 0)
		{
			MoveSpeedUp();
		}
		else if (type == 1)
		{
			EnemyStun();
		}
	}

	void NegativeItem()
	{
		int type = -1;
		//type = Random.Range(0, 3);
		type = 1;
		if (type == 0)
		{ }
		else if (type == 1)
		{
			MoveSpeedDown();
		}
	}

	void MoveSpeedUp()
	{
		Debug.Log("이속 증가");
		MoveSpeedUpItemTime = 0.0f;
			MoveSpeedUpItem = true;
		GameObject Parent = null;
		Parent = GameObject.Find("UI Root/Camera");
		GameObject item = null;
		GameObject temp = Resources.Load("Prefabs/Game/UI/SpeedUp") as GameObject;
		item = Instantiate(temp);
		item.transform.SetParent(Parent.transform);
		item.transform.localPosition = Vector3.zero;
		item.transform.localScale = Vector3.one;
		//Destroy(PlayerA.gameObject);
		//PlayerA.transform.localPosition = new Vector3(0, 10, 0);
	}

	void EnemyStun()
	{
		Debug.Log("적 스턴");
		GameObject Hammer = null;
		
		GameObject temp = Resources.Load("Prefabs/Game/Hammer") as GameObject;

		Debug.Log(temp);
		
			//PlayerB.transform.localPosition
			Hammer = Instantiate(temp,  BPlayer.transform.localPosition, Quaternion.identity);
			 

			Debug.Log(BPlayer);
			if (BPlayer == null)
				Debug.Log("playerB is null");
			BPlayer.GetComponent<PlayerB>().StunItem = true;
			BPlayer.GetComponent<PlayerB>().StunItemTime = 0.0f;

			Invoke("WaitPlayerBPress", 0.5f);
		

	
		Hammer.transform.localPosition += new Vector3(0, 9, 0);
		Hammer.transform.localRotation = Quaternion.Euler(0, 90, 180);

	}
	void MoveSpeedDown()
	{
		Debug.Log("이속 감소");
		MoveSpeedDownItemTime = 0.0f;
		
			MoveSpeedDownItem = true;
		GameObject Parent = null;
		Parent = GameObject.Find("UI Root/Camera");
		GameObject item = null;
		GameObject temp = Resources.Load("Prefabs/Game/UI/SpeedDown") as GameObject;
		item = Instantiate(temp);
		item.transform.SetParent(Parent.transform);
		item.transform.localPosition = Vector3.zero;
		item.transform.localScale = Vector3.one;



	}


	public void MyStun()
	{
		GameObject Parent = null;
		Parent = GameObject.Find("UI Root/Camera");
		GameObject item = null;
		GameObject temp = Resources.Load("Prefabs/Game/UI/Stun") as GameObject;
		item = Instantiate(temp);
		item.transform.SetParent(Parent.transform);
		item.transform.localPosition = Vector3.zero;
		item.transform.localScale = Vector3.one;
	}
	//void WaitPlayerAPress()
	//{
	//	this.transform.localScale = new Vector3(1, 0.05f, 1);
	//}

	void WaitPlayerBPress()
	{
		BPlayer.transform.localScale = new Vector3(1, 0.05f, 1);
		BPlayer.GetComponent<PlayerB>().MyStun();
	}

}
