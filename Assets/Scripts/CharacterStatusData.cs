using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 실제 캐릭터에 적용 클래
public class CharacterStatusData
{
	// 키값을 string으로
    Dictionary<string, StatusData> DicStatus = new Dictionary<string, StatusData>(); //스킬 이면 스킬 등관리

    bool bRefresh = false;
    StatusData TotalStatus = new StatusData();

    public void AddStatusData(string strKey, StatusData statusData)
    {
        DicStatus.Remove(strKey);
        DicStatus.Add(strKey, statusData);
        bRefresh = true;
    }

    public void RemoveSattusData(string strKey)
    {
        DicStatus.Remove(strKey);
        bRefresh = true;
    }

	// 최신화가 뭔지
    public double GetStatusData(eStatusData statusData)
    {
		// 리프레쉬 검사
        RefreshTotalStatus();
        return TotalStatus.GetStatusData(statusData);
    }
    void RefreshTotalStatus()
    {
		// true면 내려가고 false면 다시 올라간다.
		if (bRefresh == false)
            return;

        TotalStatus.InitData();

        foreach (KeyValuePair<string, StatusData> pair in DicStatus)
        {
            StatusData data = pair.Value;
            TotalStatus.Copy(data);
        }
        bRefresh = false;
    }
}
