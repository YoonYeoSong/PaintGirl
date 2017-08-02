using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Actor {

	//Transform Target = null;
	MonsterRegenerator Generator;

	//public override void ThrowEvent(string keyData, params object[] datas)
	//{
	//	switch (keyData)
	//	{

	//		case ConstValue.EventKey_EnemyInit:
	//			{
	//				Generator = datas[0] as MonsterRegenerator;
	//			}
	//			break;
	//		default:
	//			{
	//				base.ThrowEvent(keyData, datas);
	//			}
	//			break;
	//	}
	//}

	//public new void OnDisable()
	//{
	//	if (Generator != null)
	//		Generator.RemoveActor(this);

	////	base.OnDisable();
	//}

	//// 부모것을 완전히 재정히 할때
	//// override는 virtual일 경우
	//public new void OnDestroy()
	//{
	//	if (Generator != null)
	//		Generator.RemoveActor(this);

	//	base.OnDestroy();
	//}




	//private void OnTriggerEnter(Collider other)
	//{
	//	if(other.gameObject.name.Equals("Player"))
	//	{
	//		Target = other.transform;
	//		StartCoroutine("FollowTarget");
	//	}	
	//}

	//private void OnTriggerExit(Collider other)
	//{
	//	if(other.gameObject.name.Equals("Player"))
	//	{
	//		Target = null;
	//		StopCoroutine("FollowTarget");
	//	}
	//}

	//IEnumerator FollowTarget()
	//{		
	//	while(Target != null)
	//	{
	//		SelfComponent<NavMeshAgent>().Resume();
	//		SelfComponent<NavMeshAgent>().SetDestination(Target.position);

	//		yield return new WaitForSeconds(0.3f);
	//	}

	//	yield return null;
	//}

}
