using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
public class WeaponInfo   {

	string StrKey = string.Empty;
	string Name = string.Empty;
	int Damage = 0;
	int Range = 0;
	float AttackSpeed = 0.0f;

	public string KEY { get { return StrKey; } }
	public string NAME { get { return Name; } }
	public int DAMAGE { get { return Damage; } }
	public int RANGE { get { return Range; } }
	public float ATTACKSPEED { get { return AttackSpeed; } }


	public WeaponInfo(string _strKey, JSONNode nodeData)
	{
		StrKey = _strKey;
		Name = nodeData["MACHINEGUN"];
		Damage = nodeData["DAMAGE"].AsInt;
		Range = nodeData["RANGE"].AsInt;
		AttackSpeed = nodeData["ATTACKSPEED"].AsFloat;
	}
}
