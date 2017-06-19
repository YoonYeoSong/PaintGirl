using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter
{
    public BaseObject TargetComponenet = null;

    CharacterTemplateData TemplateData = null;

    CharacterStatusData CharacterStatus = new CharacterStatusData();

    public CharacterTemplateData CHARACTER_TEMPLATE
    { get { return TemplateData; } }
    public CharacterStatusData CHARACTER_STATUS
    { get { return CharacterStatus; } }

    double CurrentHP = 0;
    public double CURRENT_HP
    { get { return CurrentHP; } }

    // 스킬 데이터

	public SkillData SELECT_SKILL
	{
		get;
		set;
	}
	List<SkillData> ListSkill = new List<SkillData>();

    public void IncreaseCurrentHP(double valueData)
    {
        CurrentHP += valueData;
        if (CurrentHP < 0)
            CurrentHP = 0;

        double maxHP = CharacterStatus.GetStatusData(eStatusData.MAX_HP);
        if (CurrentHP > maxHP)
            CurrentHP = maxHP;

        if (CurrentHP == 0)
            TargetComponenet.OBJECT_STATE = eBaseObjectState.STATE_DIE;	
    }

    public void SetTemplate(CharacterTemplateData _templateData)
    {
        TemplateData = _templateData;
        CharacterStatus.AddStatusData(ConstValue.CharacterStatusDataKey, TemplateData.STATUS);
        CurrentHP = CharacterStatus.GetStatusData(eStatusData.MAX_HP);
    }

	public void AddSkill(SkillData skillData)
	{
		ListSkill.Add(skillData);
	
	}

	public SkillData GetSkillByIndex(int index)
	{
		if(ListSkill.Count > index)
		{
			return ListSkill[index];
		}
		return null;
	}
		

}
