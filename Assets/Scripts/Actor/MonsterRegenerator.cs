using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRegenerator : BaseObject {

	//private GameObject MonsterPrefab = null;
	//List<Actor> ListAttachMonster = new List<Actor>();

	//public eRegeneratorType RegenType = eRegeneratorType.NONE;
	//public eMonsterType MonsterType = eMonsterType.B_Monster;

	//public int MaxObjectNum = 0;

	//// RegenTime Event
	//public float RegenTime = 300.0f;
	//private float CurrTime = 0.0f;

	//// Trigger Event
	//public float Radius = 15.0f;

	//private void OnEnable()
	//{
	//	MonsterPrefab = ActorManager.Instance.GetMonsterPrefab(MonsterType);
	//	//Resources.Load("Prefabs/" + MonsterType.ToString()) as GameObject;

	//	if(MonsterPrefab == null)
	//	{
	//		Debug.LogError("몬스터 프리팹 로드 실패");
	//		return;
	//	}

	//	switch(RegenType)
	//	{
	//		case eRegeneratorType.REGENTIME_EVENT:
	//			{
	//				CurrTime = 0.0f;

	//			}
	//			break;
	//		case eRegeneratorType.TRIGGER_EVENT:
	//			{
	//				SelfComponent<SphereCollider>().isTrigger = true;
	//				SelfComponent<SphereCollider>().radius = Radius;
	//			}
	//			break;
	//	}
	//}

	//private void Update()
	//{
	//	// 생성 체크
	//	switch(RegenType)
	//	{
	//		case eRegeneratorType.REGENTIME_EVENT:
	//			{
	//				if (RegenTime > CurrTime)
	//					CurrTime += Time.deltaTime;
	//				else
	//				{
	//					CurrTime = 0;
	//					//RegenMonster();
	//				}
	//			}
	//			break;
	//		case eRegeneratorType.TRIGGER_EVENT:
	//			break;
	//	}
		
	//}

	////void RegenMonster()
	////{
	////	for(int i = ListAttachMonster.Count; i < MaxObjectNum; i++)
	////	{
	////		Actor actor = ActorManager.Instance.InstantiateOnce(MonsterPrefab,SelfTransform.position + GetRandomPos());

	////		// 몬스터연결
	////		actor.ThrowEvent(ConstValue.EventKey_EnemyInit, this);

	////		ListAttachMonster.Add(actor);
	////	}
	////}

	//Vector3 GetRandomPos()
	//{
	//	Vector3 dir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));

	//	return dir.normalized * Random.Range(1, Radius);
	//}

	//private void OnTriggerEnter(Collider other)
	//{
	//	switch (RegenType)
	//	{
	//		case eRegeneratorType.REGENTIME_EVENT:
	//			break;
	//		case eRegeneratorType.TRIGGER_EVENT:
	//			{
	//				Actor actor = other.gameObject.GetComponent<Actor>();
	//				if(actor != null && actor.IS_PLAYER == true) //actor.gameObject.name.Contains("Player")
	//				{
	//					//RegenMonster();
	//				}
	//			}
	//			break;
	//	}

	//}

	//public void RemoveActor(Actor actor)
	//{
	//	if (ListAttachMonster.Contains(actor) == true)
	//		ListAttachMonster.Remove(actor);
	//	else
	//	{

	//		return;
	//	}
	//}
}
