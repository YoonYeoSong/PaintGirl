using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorManager : MonoSingleton<ActorManager> {

	// 하이라키 관리용
	Transform ActorRoot = null;
	
	// 모든 엑터 관리
	Dictionary<eTeamType, List<Actor>> DicActor = new Dictionary<eTeamType, List<Actor>>();

	// 몬스터 프리팹 관리
	Dictionary<eMonsterType, GameObject> DicMonsterPrefab = new Dictionary<eMonsterType, GameObject>();


	bool TeamA; //팀 구별 

	private void Awake()
	{
		MonsterPrefabInit();

		TeamA = true;
	}

	void MonsterPrefabInit()
	{
		for(int i = 0; i < (int)eMonsterType.MAX; i++)
		{
			GameObject go = Resources.Load("Prefabs/" + ((eMonsterType)i).ToString("F")) as GameObject;

			if(go == null)
			{
				Debug.LogError(((eMonsterType)i).ToString("F") + "Load Failed");
			}
			else
			{
				DicMonsterPrefab.Add((eMonsterType)i, go);
			}
		}
	}

	public GameObject GetMonsterPrefab(eMonsterType type)
	{
		if(DicMonsterPrefab.ContainsKey(type) == true)
		{
			return DicMonsterPrefab[type];
		}
		else
		{
			Debug.Log(type.ToString() + " 타입의 몬스터 프리팹이 없습니다. ");
			return null;
		}
	}

	//public Actor InstantiateOnce(GameObject prefab, Vector3 pos)
	//{
	//	if(prefab == null)
	//	{
	//		Debug.LogError("프리팹이 null 입니다. [ActorManager.InstantiateOnce()]");
	//		return null;
	//	}
	//	//GameObject go = Instantiate(prefab, pos, Quaternion.identity) as GameObject;

	//	if(ActorRoot == null)
	//	{
	//		GameObject temp = new GameObject();
	//		temp.name = "ActorRoot";
	//		ActorRoot = temp.transform;
	//	}

	//	//go.transform.SetParent(ActorRoot);
	//	//return go.GetComponent<Actor>();
	//}

	public void AddActor(Actor actor)
	{
		List<Actor> listActor = null;
		//eTeamType teamType = actor.TEAM_TYPE;

		// 리스트 생성 또는 로드
		//if(DicActor.ContainsKey(teamType) == false)
		//{
		//	listActor = new List<Actor>();
		//	DicActor.Add(teamType, listActor);
		//}
		//else
		//{
		//	DicActor.TryGetValue(teamType, out listActor);
		//}

		listActor.Add(actor);

	}
	public void RemoveActor(Actor actor, bool bDelete = false)
	{
		//eTeamType teamType = actor.TEAM_TYPE;

		//if(DicActor.ContainsKey(teamType) == true)
		//{
		//	List<Actor> listActor = null;
		//	DicActor.TryGetValue(teamType, out listActor);
		//	listActor.Remove(actor);
		//}
		//else
		//{
		//	Debug.LogError("존재 하지 않는 엑터를 삭제하려고 합니다.");
		//}
		if (bDelete)
			Destroy(actor.gameObject);
	}

	// Test Code
	//public BaseObject GetSearchEnemy(BaseObject actor, out float returnDist, float radius = 100.0f)
	//{
	//	eTeamType teamType = (eTeamType)actor.GetData(ConstValue.ActorData_Team);
	//	Vector3 myPosition = actor.SelfTransform.position;
	//	float nearDistance = radius;
	//	Actor nearActor = null;
	//	returnDist = 0;

	//	foreach (KeyValuePair<eTeamType, List<Actor>> pair in DicActor)
	//	{
	//		if (pair.Key == teamType)
	//			continue;

	//		for (int i = 0; i < pair.Value.Count; i++)
	//		{
	//			if (pair.Value[i].SelfObject.activeSelf == false)
	//				continue;

	//			if (pair.Value[i].OBJECT_STATE == eBaseObjectState.STATE_DIE)
	//				continue;

	//			float distance = Vector3.Distance(myPosition, pair.Value[i].SelfTransform.position);
	//			if (distance < nearDistance)
	//			{
	//				nearDistance = distance;
	//				nearActor = pair.Value[i];
	//				returnDist = nearDistance;
	//			}
	//		}
	//	}
	//	return nearActor;
	//}



	public BaseObject GetSearchEnemy(BaseObject actor, float radius = 100.0f)
	{
		eTeamType teamType = (eTeamType)actor.GetData(ConstValue.ActorData_Team);
		Vector3 myPosition = actor.SelfTransform.position;
		float nearDistance = radius;
		Actor nearActor = null;

		foreach(KeyValuePair<eTeamType, List<Actor>> pair in DicActor)
		{
			if (pair.Key == teamType)
				continue;

			for(int i = 0; i < pair.Value.Count; i++)
			{
				if (pair.Value[i].SelfObject.activeSelf == false)
					continue;

				if (pair.Value[i].OBJECT_STATE == eBaseObjectState.STATE_DIE)
					continue;

				float distance = Vector3.Distance(myPosition, pair.Value[i].SelfTransform.position);
				if(distance < nearDistance)
				{
					nearDistance = distance;
					nearActor = pair.Value[i];
				}
			}
		}
		return nearActor;
	}


	//public Actor PlayerLoad()
	//{
	//	GameObject playerA = Resources.Load("Prefabs/" + "Charactor/" + "PlayerA") as GameObject;
	//	GameObject playerB = Resources.Load("Prefabs/" + "Charactor/" + "PlayerB") as GameObject;
	//	GameObject go = null;
	//	GameObject StartingPoint = null;


		//if (TeamA == true)
		//{
		//	//StartingPoint = GameObject.Find("STAGE_1(Clone)").transform.FindChild("APlayerStartPoint").FindChild("StartingPoint").gameObject;
		//	 go = Instantiate(playerA, new Vector3(-8.78f,4.69f,-28.04f), Quaternion.identity) as GameObject;
		//	go.name = "PlayerA";
		//	go.gameObject.AddComponent<Player>();
		//	Debug.Log("팀A생성");
		//}

		//TeamA = false; // 팀체크 

		//if (TeamA == false)
		//{
		//	StartingPoint = GameObject.Find("STAGE_1(Clone)").transform.FindChild("BPlayerStartPoint").FindChild("StartingPoint").gameObject;
		//	go = Instantiate(playerB, new Vector3(-8.82f, 4.37f, 26.46f), Quaternion.identity) as GameObject;
		//	go.name = "PlayerB";
		//	go.gameObject.AddComponent<PlayerB>();
		//	Debug.Log("팀B생성");
		//}

		//go.GetComponent<Player>().enabled = true;
		//<<<<<<< HEAD
		//go.GetComponent<CapsuleCollider>().enabled = true;
		//go.GetComponent<NavMeshAgent>().enabled = true;
		//=======
		//go.GetComponent<CapsuleCollider>().enabled = true;
		//go.GetComponent<NavMeshAgent>().enabled = true;
		//>>>>>>> 52fd23f1704dc24410a5800a3cdb50b4c96dc6b0

		//return go.GetComponent<Actor>();
	//}
}
