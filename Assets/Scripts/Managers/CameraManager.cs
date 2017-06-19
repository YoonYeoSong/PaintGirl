using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    public Camera MainCamera;
    public Transform Target;
    public float Distance = 10.0f;
    public float Height = 5.0f;

    public float HeightDamping = 2.0f;
    public float WidthDamping = 3.0f;

    public void CameraInit(Actor Player)
    {
        MainCamera = Camera.main;
        Target = Player.SelfTransform;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Target == null)
            return;

        float wantedHeight = Target.position.y + Height;
        float currentHeight = MainCamera.transform.position.y;
        float wantedWidth = Target.position.x;
        float currentWidth = MainCamera.transform.position.x;
		
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);
        currentWidth = Mathf.Lerp(currentWidth, wantedWidth, WidthDamping * Time.deltaTime);

        Vector3 pos = Target.position;
        pos -= MainCamera.transform.forward * Distance;

        MainCamera.transform.position = new Vector3(currentWidth, currentHeight, pos.z);
        MainCamera.transform.LookAt(Target);
    }
}
