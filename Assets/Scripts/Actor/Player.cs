using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Actor
{

	//JoyStick Stick;
	NavMeshAgent Agent;

	//private void Start()
	//{
	//	IS_PLAYER = true;
	//	//Stick = JoyStick.Instance;
	//	//Agent = SelfComponent<NavMeshAgent>();

	//	Anim = this.GetComponentInChildren<Animator>();

	//}

	//protected override void Update()
	//{
	//	if (Stick.IsPressed)
	//	{
	//		Vector3 movePosition = transform.position;
	//		movePosition += new Vector3(Stick.Axis.x, 0, Stick.Axis.y);


	//		AI.ClearAI();
	//		Agent.Resume();
	//		Agent.SetDestination(movePosition);
	//		ChangeState(eStateType.STATE_WALK);
	//	}
	//	else
	//	{
	//		base.Update();
	//	}
	//}

	#region 예전
	Animator Anim;

	JoyStick Stick;

	DetectionArea DetectArea;

	Rigidbody rigi;
	float AttackRange = 3.0f;
	void Start()
	{
		IS_PLAYER = true;
		Agent = SelfComponent<NavMeshAgent>();
		Anim = this.GetComponentInChildren<Animator>();
		Stick = JoyStick.Instance;
		rigi = GetComponent<Rigidbody>();

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
	}

	protected override void Update()
	{
		if (Stick.IsPressed)
		{
			//Vector3 Axis = JoyStick.Instance.Axis;
			//Vector3 pos = new Vector3(Axis.x, 0, Axis.y);

			Vector2 Axis = Stick.Axis;
			Vector3 MovePosition = new Vector3(0, 0, 0);
			Vector3 MoveRotation = new Vector3(0, 0, 0);


			//Vector3 MovePosition = transform.position;
			MovePosition += new Vector3(Axis.x, 0, Axis.y);
			//MoveRotation += new Vector3(Axis.x, 0, Axis.y);
			SelfTransform.position += MovePosition * Time.deltaTime * 2;
			SelfTransform.rotation = Quaternion.LookRotation(MovePosition);

			//Quaternion newRotation = Quaternion.LookRotation(SelfTransform.position);
			//rigi.rotation = Quaternion.Slerp(rigi.rotation, newRotation, 10.0f * Time.deltaTime);
			//this.SelfComponent<NavMeshAgent>().SetDestination(MovePosition);
			//AI.ClearAI();
			//Agent.Resume();
			//Agent.SetDestination(MovePosition);


			ChangeState(eStateType.STATE_WALK);
		}
		else
		{
			ChangeState(eStateType.STATE_IDLE);
			base.Update();
		}	
	}

	//TEST CODE

	eStateType State = eStateType.STATE_IDLE;
	void ChangeState(eStateType type)
	{
		if (State == type)
			return;

		State = type;
		SetAnimation(State);

		switch (State)
		{
			case eStateType.STATE_IDLE:
				break;
			case eStateType.STATE_ATTACK:
				{
					//DetectionArea

				   Actor actor = DetectArea.GetFirst();
					if (actor != null)
					{
						Vector3 dir = actor.SelfTransform.position - SelfTransform.position;

						dir.Normalize();
						SelfTransform.rotation = Quaternion.LookRotation(dir);
						//actor.SelfTransform.rotation = Quaternion.LookRotation(-dir);

						//actor.ThrowEvent(ConstValue.EventKey_Hit, SELF_CHARACTER);
					}
				}
				break;
			case eStateType.STATE_WALK:
				break;
			case eStateType.STATE_DEAD:
				break;
			default:
				break;
		}
	}



	public void SetAnimation(eStateType state)
	{
		Anim.SetInteger("State", (int)state);
		//Anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}

	public override void ThrowEvent(string keyData, params object[] datas)
	{
		switch (keyData)
		{
			case "AttackEnd":
				{
					SetAnimation((eStateType)datas[0]);
				}
				break;
			default:
				{
					base.ThrowEvent(keyData, datas);
				}
				break;
		}
	}
	#endregion

}
