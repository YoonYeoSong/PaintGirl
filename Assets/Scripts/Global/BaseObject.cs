using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    Dictionary<string, UnityEngine.Component> DicComponent = new Dictionary<string, Component>();

    BaseObject TargetComponent = null;
    public BaseObject Target
    {
        get { return TargetComponent; }
        set { TargetComponent = value; }
    }

    eBaseObjectState ObjectState = eBaseObjectState.STATE_NORMAL;
    public eBaseObjectState OBJECT_STATE
    {
        get
        {
            if (Target == null)
                return ObjectState;
            else
                return Target.ObjectState;
        }
        set
        {
            if (Target == null)
                ObjectState = value;
            else
                Target.ObjectState = value;
        }
    }

    public GameObject SelfObject
    {
        get
        {
            if (Target == null)
                return this.gameObject;
            else
                return Target.gameObject;
        }
    }

    public Transform SelfTransform
    {
        get
        {
            if (Target == null)
                return this.transform;
            else
                return Target.transform;
        }
    }

    // 이벤트 관련

    // object[] -> GetData("State","Attack","3"); :: datas[2] ("Attck", "3")
    public virtual object GetData(string keyData, params object[] datas)
    {
        return null;
    }
    public virtual void ThrowEvent(string keyData, params object[] datas) // params -> 시스템에서 최상위 오브젝트, Object -> 유니티에서 최상위 오브젝트
    {

    }

    public Transform FindInChild(string strName)
    {
        return _FindInChild(strName, SelfTransform);
    }
    Transform _FindInChild(string strName, Transform trans)
    {
        if (trans.name == strName)
            return trans;
        for (int i = 0; i < trans.childCount; i++)
        {
            Transform returnTrans = _FindInChild(strName, trans.GetChild(i));
            if (returnTrans != null)
                return returnTrans;
        }
        return null;
    }
    // T -> 한정자( 컴포넌트만 받음 )
    public T SelfComponent<T>() where T : UnityEngine.Component
    {
        string objectName = string.Empty;
        string typeName = typeof(T).ToString();
        T tempComponent = default(T);

        objectName = this.gameObject.name;

        if (Target == null)
        {
            if (DicComponent.ContainsKey(typeName))
            {
                tempComponent = DicComponent[typeName] as T;
            }
            else
            {
                tempComponent = this.GetComponent<T>();
                if (tempComponent == null)
                {
                    Debug.LogError("objectName : " + objectName + ", Missing Component : " + typeName);
                    tempComponent = this.gameObject.AddComponent<T>();
                }
                else
                {
                    DicComponent.Add(typeName, tempComponent);
                }
            }
        }
        else
        {
            objectName = Target.SelfObject.name;
            tempComponent = TargetComponent.SelfComponent<T>();
        }

        return tempComponent;
    }
}
