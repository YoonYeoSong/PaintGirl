using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
// 데이터, 템플릿 가지고 있다
public class SkillManager : MonoSingleton<SkillManager>
{

	// 사용한 스킬들의 오브젝트들 어떤 actor가 썼는지 actor가 사용한 스킬들
	Dictionary<BaseObject, List<BaseSkill>> DicUseSkill = new Dictionary<BaseObject, List<BaseSkill>>();

	Dictionary<string, SkillData> DicSkillData = new Dictionary<string, SkillData>();

	Dictionary<string, SkillTemplate> DicSkillTemplate = new Dictionary<string, SkillTemplate>();

	Dictionary<eSkillModelType, GameObject> DicModel = new Dictionary<eSkillModelType, GameObject>();

	private void Awake()
	{
		LoadSkillData(ConstValue.SkillDataPath);
		LoadSkillTemplate(ConstValue.SkillTemplatePath);
		LoadSkillModel();
	}


	void LoadSkillData(string strFilePath)
	{
		TextAsset skillAssetData = Resources.Load(strFilePath) as TextAsset;
		if (skillAssetData == null)
		{
			Debug.LogError("Skill Data 불러오지 못함");
		}
		JSONNode rootNode = JSON.Parse(skillAssetData.text);
		if (rootNode == null)
			return;

		JSONObject skillDataNode = rootNode["SKILL_DATA"] as JSONObject;
		foreach (KeyValuePair<string, JSONNode> pair in skillDataNode)
		{
			SkillData skillData = new SkillData(pair.Key, pair.Value);
			DicSkillData.Add(pair.Key, skillData);
		}
	}

	void LoadSkillTemplate(string strFilePath)
	{
		TextAsset skillAssetData = Resources.Load(strFilePath) as TextAsset;

		if (skillAssetData == null)
		{
			Debug.LogError("Skill TempLate 로드 실패");
			return;
		}
		JSONNode rootNode = JSON.Parse(skillAssetData.text);
		if (rootNode == null)
			return;

		JSONObject skillDataNode = rootNode["SKILL_TEMPLATE"] as JSONObject;
		foreach (KeyValuePair<string, JSONNode> pair in skillDataNode)
		{
			SkillTemplate skillTemplate = new SkillTemplate(pair.Key, pair.Value);
			DicSkillTemplate.Add(pair.Key, skillTemplate);
		}
	}

	public void LoadSkillModel()
	{
		for (int i = 0; i < (int)eSkillModelType.MAX; i++)
		{
			GameObject go = Resources.Load("Prefabs/Skill_Models/" + ((eSkillModelType)i).ToString()) as GameObject;
			if (go == null)
			{
				Debug.LogError("Prefabs/Skill_Models/" + ((eSkillModelType)i).ToString() + "파일을 찾기 못함");
				continue;
			}

			DicModel.Add((eSkillModelType)i, go);

		}
	}


	public GameObject GetModel(eSkillModelType type)
	{
		// 키값이 있는지
		if (DicModel.ContainsKey(type))
		{
			return DicModel[type];
		}
		else
		{
			Debug.LogError(type.ToString() + "is null");
			return null;
		}
	}

	public SkillData GetSkillData(string _strKey)
	{
		SkillData skillData = null;
		// 어떤 키값을 찾아 넘겨준다.
		DicSkillData.TryGetValue(_strKey, out skillData);
		return skillData;
	}

	public SkillTemplate GetSkillTemplate(string _strKey)
	{
		SkillTemplate skillTempLate = null;
		DicSkillTemplate.TryGetValue(_strKey, out skillTempLate);
		return skillTempLate;
	}

	public void RunSkill(BaseObject keyObject, string strSkillTemplateKey)
	{
		// 템플릿키를 던져주고
		SkillTemplate template = GetSkillTemplate(strSkillTemplateKey);
		// 딕에서 꺼내와 널인지 판별
		if (template == null)
		{
			Debug.LogError(strSkillTemplateKey + "키를 찾을 수 없습니다.");
			return;
		}
		// 베이스 스킬 생성
		BaseSkill runSkill = CreateSkill(keyObject, template);
		RunSkill(keyObject, runSkill);
	}

	public void RunSkill(BaseObject keyObject, BaseSkill runSkill)
	{
		List<BaseSkill> listSkill = null;
		// 딕셔너리 에 키가 있는지 없는지 확인
		if (DicUseSkill.ContainsKey(keyObject) == false)
		{
			listSkill = new List<BaseSkill>();
			DicUseSkill.Add(keyObject, listSkill);
		}
		else
		{
			listSkill = DicUseSkill[keyObject];
		}
		// 리스트 스킬 세팅 

		// 된것을 add
		listSkill.Add(runSkill);
	}


	BaseSkill CreateSkill(BaseObject owner, SkillTemplate skillTemplate)
	{
		BaseSkill makeSkill = null;
		GameObject skillObject = new GameObject();
		Transform parentTransform = null;

		switch (skillTemplate.SKILL_TYPE)
		{
			case eSkillTemplateType.TARGET_ATTACK:
				makeSkill = skillObject.AddComponent<MeleeSkill>();
				parentTransform = owner.SelfTransform;
				break;
			case eSkillTemplateType.RANGE_ATTACK:
				{
					makeSkill = skillObject.AddComponent<RangeSkill>();
					parentTransform = owner.FindInChild("FirePos"); //SelfTransform;

					makeSkill.ThrowEvent(ConstValue.EventKey_SelectModel, GetModel(eSkillModelType.BOX));
				}
				break;
		}
		skillObject.name = skillTemplate.SKILL_TYPE.ToString();

		if (makeSkill != null)
		{
			// 스킬이 널이아니라면 

			makeSkill.transform.position = parentTransform.position;
			makeSkill.transform.rotation = parentTransform.rotation;

			makeSkill.OWNER = owner;
			makeSkill.SKILL_TEMPLATE = skillTemplate;
			//onwer가 바라보고 있는 타겟을 넘겨준다.
			makeSkill.TARGET = owner.GetData(ConstValue.ActorData_GetTarget) as BaseObject;

			makeSkill.InitSkill();

			switch (skillTemplate.RANGE_TYPE)
			{
				case eSkillAttackRangeType.RANGE_BOX:
					{
						BoxCollider collider = skillObject.AddComponent<BoxCollider>();
						collider.size = new Vector3(skillTemplate.RANGE_DATA_1, 1, skillTemplate.RANGE_DATA_2);
						collider.center = new Vector3(0, 0, skillTemplate.RANGE_DATA_2 * 0.5f);
						collider.isTrigger = true;
					}
					break;
				case eSkillAttackRangeType.RANGE_SPHERE:
					{
						SphereCollider collider = skillObject.AddComponent<SphereCollider>();
						collider.radius = skillTemplate.RANGE_DATA_1;
						collider.isTrigger = true;
					}
					break;
			}

		}
		return makeSkill;
	}

	public void Update()
	{
		if (GameManager.Instance.GAME_OVER)
			return;

		foreach (KeyValuePair<BaseObject, List<BaseSkill>> pair in DicUseSkill)
		{
			List<BaseSkill> list = pair.Value;

			for (int i = 0; i < list.Count; i++)
			{
				BaseSkill updateSkill = list[i];

				updateSkill.UpdateSkill();

				if (updateSkill.END)
				{
					list.Remove(updateSkill);
					Destroy(updateSkill.gameObject);
				}
			}
		}

	}

	public void ClearSkill()
	{
		foreach (KeyValuePair<BaseObject, List<BaseSkill>> pair in DicUseSkill)
		{
			List<BaseSkill> list = pair.Value;

			for (int i = 0; i < list.Count; i++)
			{
				BaseSkill updateSkill = list[i];
				list.Remove(updateSkill);
				Destroy(updateSkill.gameObject);
			}
		}
		DicUseSkill.Clear();
	}

}
