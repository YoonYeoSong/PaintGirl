using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


public class SkillData
{

	string StrKey = string.Empty;
	float Range = 0;

	List<string> SkillList = new List<string>();

	public float RANGE { get { return Range;  } }

	// Skill Template Key
	public List<string> SKILL_LIST { get { return SkillList; } }


	public SkillData(string _strKey, JSONNode nodeData)
	{
		StrKey = _strKey;
		Range = nodeData["RANGE"].AsFloat;

		JSONArray arrSkill = nodeData["SKILL"].AsArray;
		if(arrSkill != null)
		{
			for(int i = 0; i < arrSkill.Count; i++)
			{
				SkillList.Add(arrSkill[i]);
			}
		}
	}


}

