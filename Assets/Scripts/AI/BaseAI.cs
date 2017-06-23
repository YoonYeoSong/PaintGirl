using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// 다음 ai넘어가기 위한 준비단계  
public class NextAI
{
	public eStateType StateType;
	public BaseObject TargetObject;
	public Vector3 Position;
}


public class BaseAI : BaseObject {

	protected List<NextAI> ListNextAI = new List<NextAI>(); // 내가 행동하는것을 담아둔다.
	protected eStateType CurrentAIState = eStateType.STATE_IDLE;

	// 항상 최신화를 위해
	public eStateType CURRENT_AI_STATE
	{
		get
		{
			return CurrentAIState;
		}
	}

	// true면 돌지 않도록 끝난판독은 false로
	bool bUpdateAI = false;
	// 공격 중인지 아닌지 판단
	bool bAttack = false;

	public bool IS_ATTACK
	{
		get
		{
			return bAttack;
		}
		set
		{
			bAttack = value;
		}
	}

	// ai가 끝나 삭제 판단은 end로
	bool bEnd = false;
	public bool END
	{
		get
		{
			return bEnd;
		}
		set
		{
			bEnd = value;
		}
	}

	// 내부 메쉬에 데스트 네이션을 설정
	protected Vector3 MovePosition = Vector3.zero;
	Vector3 PreMovePosition = Vector3.zero; // 이전 위치 저장

	// 애니메이션을 위해 가져오고
	Animator Anim = null;
	NavMeshAgent NavAgent = null;

	// anim이 널인지 아닌지
	public Animator ANIMATOR
	{
		get
		{
			if(Anim == null)
			{
				// actor 하위 모델에 
				Anim = SelfObject.GetComponentInChildren<Animator>();
				// actor의 자식 중에 애니메이터를 가져오겠다.
			}
			return Anim;
		}
	}

	public NavMeshAgent NAV_MESH_AGENT
	{
		get
		{
			if(NavAgent == null)
			{
				NavAgent = SelfObject.GetComponent<NavMeshAgent>();
				
			}
			return NavAgent;
		}
	}

	// ani메이터가 있는지 없는지 판독
	void ChangeAnimation()
	{
		if(ANIMATOR == null)
		{
			Debug.LogError(SelfObject.name + "에게 animator가 없습니다.");
			return;
		}
		// 파라미터들을 가지고 처리할 수 있도록
		ANIMATOR.SetInteger("State", (int)CurrentAIState);
	}

	// 다음 ai를 셋팅한다.  위치값 초기화
	public virtual void AddNextAI(eStateType nextStateType, BaseObject targetObject = null, Vector3 position = new Vector3())
	{
		// 클래스
		NextAI nextAI = new NextAI();
		// 인자들을 셋팅하고
		nextAI.StateType = nextStateType;
		nextAI.TargetObject = targetObject;
		nextAI.Position = position;

		// 리스트에 저장 나중에 순차적으로 실행
		ListNextAI.Add(nextAI);
	}
	


	// Process 들은 전처리
	// 오버라이드해서 가져갈 수도 있다.
	protected virtual void ProcessIdle()
	{
		CurrentAIState = eStateType.STATE_IDLE;
		ChangeAnimation();
	}

	protected virtual void ProcessMove()
	{
		CurrentAIState = eStateType.STATE_WALK;
		ChangeAnimation();
	}

	protected virtual void ProcessAttack()
	{
		// 내가 사용하고자하는 스킬을 골랐다.
		// 셀렉트 스킬에 0번째 스킬을 셋팅
		// 만약 공격 버튼이 4개다 하면 나누는게 편하다
		Target.ThrowEvent(ConstValue.EventKey_SelectSkill, 0);
		CurrentAIState = eStateType.STATE_ATTACK;
		ChangeAnimation();
	}

	protected virtual void ProcessDead()
	{
		CurrentAIState = eStateType.STATE_DEAD;
		ChangeAnimation();
	}

	// 상속받은 애가 override (이것을 대체해 사용중)
	protected virtual IEnumerator Idle()
	{
		bUpdateAI = false;
		yield break;
	}
	protected virtual IEnumerator Move()
	{
		bUpdateAI = false;
		yield break;
	}
	protected virtual IEnumerator Attack()
	{
		bUpdateAI = false;
		yield break;
	}
	protected virtual IEnumerator Dead()
	{
		bUpdateAI = false;
		yield break;

	}


	// 전처리
	void SetNextAI(NextAI nextAI)
	{
		// 널인지 아닌지 체크 타겟이 있다면
		if(nextAI.TargetObject != null)
		{
			// 내가 바라보고있는 actor에 전달
			Target.ThrowEvent(ConstValue.ActorData_SetTarget, nextAI.TargetObject);
			// 타겟을 actor에 지정
		}

		// 포지셔이 제로가 아니면 nextia 포지션을 전달
		if (nextAI.Position != Vector3.zero)
			MovePosition = nextAI.Position;

		switch(nextAI.StateType)
		{
			case eStateType.STATE_IDLE:
				ProcessIdle();
				break;
			case eStateType.STATE_ATTACK:

				{
					if(nextAI.TargetObject != null)
					{
						// 내가 정면 위치를 방향벡터로 바꿔준다. 공격하는애를 처다볼수 있도록
						SelfTransform.forward = (nextAI.TargetObject.SelfTransform.position - SelfTransform.position).normalized;
					}
					ProcessAttack();
				}
				break;
			case eStateType.STATE_WALK:
				ProcessMove();
				break;
			case eStateType.STATE_DEAD:
				ProcessDead();
				break;

		}
	}

	
	public void UpdateAI()
	{
		if (bUpdateAI == true) // AIupdate가 돌아가고 있다면 넘어간다. 그렇지 않다면 다음 루트로
			return;

		// 카운트가 몇개가 있는지 판독
		if (ListNextAI.Count > 0)
		{
			SetNextAI(ListNextAI[0]);
			ListNextAI.RemoveAt(0);
		}

		// 상태가 die면
		if (OBJECT_STATE == eBaseObjectState.STATE_DIE)
		{
			// 리스트를 클리어
			ListNextAI.Clear();
			ProcessDead();
		}

		// true로 바꿔 업데이트에 들어오지 않도록한다.
		bUpdateAI = true;

		//
		switch (CurrentAIState)
		{
			case eStateType.STATE_IDLE:
				StartCoroutine("Idle");
				break;
			case eStateType.STATE_ATTACK:
				StartCoroutine("Attack");
				break;
			case eStateType.STATE_WALK:
				StartCoroutine("Move");
				break;
			case eStateType.STATE_DEAD:
				StartCoroutine("Dead");
				break;

		}
	}

	public void ClearAI()
	{
		ListNextAI.Clear();
	}

	public void ClearAI(eStateType stateType)
	{
		// #1 리스트 외부적 삭제
		//List<int> removeIndex = new List<int>();
		//for(int i = 0; i < ListNextAI.Count; i++)
		//{
		//	if (ListNextAI[i].StateType == stateType)
		//		removeIndex.Add(i);
		//}

		//for(int i = 0; i < removeIndex.Count; i++)
		//{
		//	ListNextAI.RemoveAt(removeIndex[i]);
		//}
		//removeIndex.Clear();


		// 내부적 삭제
		// #2 Predicate 메소드를 이용한 삭제
		//tempState = stateType;
		//ListNextAI.RemoveAll(RemovePredicate);

		// #3 Lamda식 사용
		// () => {} Lamda
		ListNextAI.RemoveAll((nextAI) => { return nextAI.StateType == stateType; });
		//ListNextAI.RemoveAll((nextAI) => nextAI.StateType == stateType);
	}


	// #2
	//eStateType tempState;
	//public bool RemovePredicate(NextAI nextAI)
	//{
	//	return nextAI.StateType == tempState;
	//}


	// 현재 이동하고 있는지
	protected bool MoveCheck()
	{
		// 이동이 완료가 됬는지
		if(NAV_MESH_AGENT.pathStatus == NavMeshPathStatus.PathComplete)
		{
			// 이동완료 가지고있는경로가 있는지?  계산중인게 있는지?
			if(NAV_MESH_AGENT.hasPath == false || NAV_MESH_AGENT.pathPending == false)
			{
				return true;
			}
		}
		return false;
	}

	// 원하는 목적지까지 이동
	protected void SetMove(Vector3 position)
	{
		if (PreMovePosition == position)
			return;

		PreMovePosition = position;
		NAV_MESH_AGENT.Resume();
		NAV_MESH_AGENT.SetDestination(position);
	}

	// 이동 멈춤
	protected void Stop()
	{
		MovePosition = Vector3.zero;
		NAV_MESH_AGENT.Stop();
	}

}
