using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CharacterManager : MonoSingleton<CharacterManager>
{
    Dictionary<string, CharacterTemplateData> DicTemplateData = new Dictionary<string, CharacterTemplateData>();

    private void Awake()
    {
        TextAsset characterText = Resources.Load(ConstValue.CharacterTemplatePath) as TextAsset;

        if (characterText != null)
        {
            JSONObject rootNodeText = JSON.Parse(characterText.text) as JSONObject; // '{'하나 까기

            if (rootNodeText != null)
            {
                JSONObject characterTemplateNode = rootNodeText[ConstValue.CharacterTemplateKey] as JSONObject;         //ConstValue.CharacterTemplateKey 첫번째 #key  

                foreach (KeyValuePair<string, JSONNode> templateNode in characterTemplateNode)
                {
                    DicTemplateData.Add(templateNode.Key, new CharacterTemplateData(templateNode.Key, templateNode.Value));
                }
            }
        }
    }

    //public CharacterTemplateData GetTemplate(string strTemplateKey)
    //{
    //    CharacterTemplateData templateData = null;
    //    DicTemplateData.TryGetValue(strTemplateKey, out templateData);
    //    if (templateData == null)
    //    {
    //        Debug.LogError("key : " + strTemplateKey + " 해당 데이터 미등록");
    //        return null;
    //    }
    //    return templateData;
    //}

    //public GameCharacter AddCharacter(string strTemplateKey)
    //{
    //    CharacterTemplateData templateData = GetTemplate(strTemplateKey);
    //    if (templateData == null)
    //        return null;

    //    GameCharacter gameCharacter = new GameCharacter();
    //    gameCharacter.SetTemplate(templateData);
    //    return gameCharacter;
    //}

}
