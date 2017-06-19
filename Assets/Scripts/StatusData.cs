using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StatusData
{
    Dictionary<eStatusData, double> DicData = new Dictionary<eStatusData, double>();

    public void InitData()
    {
        DicData.Clear();
    }

    public void Copy(StatusData data)
    {
        foreach (KeyValuePair<eStatusData, double> pair in data.DicData)
        {
            IncreaseData(pair.Key, pair.Value);
        }
    }

    public void IncreaseData(eStatusData statusData, double valueData)
    {
        double preValue = 0.0;
        DicData.TryGetValue(statusData, out preValue); // out == c++ 에서 ref와 비슷 참조
        DicData[statusData] = preValue + valueData; // dic만 키값세팅후 add
    }

    public void DecreaseData(eStatusData statusData, double valueData)
    {
        double preValue = 0.0;
        DicData.TryGetValue(statusData, out preValue);
        DicData[statusData] = preValue - valueData;
    }

    public void SetData(eStatusData statusData, double valueData)
    {
        DicData[statusData] = valueData;
    }

    public void RemoveData(eStatusData statusData, double valueData)
    {
        if (DicData.ContainsKey(statusData) == true)
            DicData.Remove(statusData);
    }

    public double GetStatusData(eStatusData statusData)
    {
        double preValue = 0.0;
        DicData.TryGetValue(statusData, out preValue);
        return preValue;
    }

	public string StatusString()
	{
		string returnStr = string.Empty;

		foreach(var pair in DicData )
		{
			returnStr += pair.Key;
			returnStr += " " + pair.Value;
			returnStr += "\n";
		}
		return returnStr;
	}
}
