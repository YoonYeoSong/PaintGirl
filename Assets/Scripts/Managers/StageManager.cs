using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class StageManager : MonoSingleton<StageManager> {


	Dictionary<int, StageInfo> DicStageInfo = new Dictionary<int, StageInfo>();
	public Dictionary<int, StageInfo> DIC_STAGEINFO
	{
		get
		{
			return DicStageInfo;
		}
	}

	public void StageInit()
	{
		TextAsset stageInfo = Resources.Load<TextAsset>("JSON/STAGE_INFO");
		JSONNode rootNode = JSON.Parse(stageInfo.text);

		foreach(KeyValuePair<string, JSONNode> pair in rootNode["STAGE_INFO"] as JSONObject)
		{
			StageInfo info = new StageInfo(pair.Key, pair.Value);
			DicStageInfo.Add(int.Parse(info.KEY), info);
		}
	}

	public StageInfo LoadStage(int _index)
	{
		StageInfo info = null;
		DicStageInfo.TryGetValue(_index, out info);

		if(info == null)
		{
			Debug.LogError("#1 JSON 정상 로드 확인" + " #2 JSON KEY 값 확인");
			return null;
		}

		//GameObject go = Resources.Load("Prefabs/Stages/STAGE_1" ) as GameObject;
		//GameObject go = Resources.Load("Prefabs/Stages/STAGE_1") as GameObject;
		//Debug.Assert(go != null, "스테이지 리소스 로드 실패");
		////GameObject model = Instantiate(go);
		//model.transform.localPosition = Vector3.zero;

		return info;
	}





}
