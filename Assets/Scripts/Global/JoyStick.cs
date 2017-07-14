using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : BaseObject
{
    //-----------------------------------------------
    // Singleton :: 조이스틱이 1개 기준
    static JoyStick _instance = null;
    public static JoyStick Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }
    //-----------------------------------------------

    public Camera UI_Camera = null;
    public bool NormalizedPower = false;

    public bool IsKeyBoardInput = false;
    public bool IsPressed = false;

    private Vector2 _Axis;
    public Vector2 Axis
    {
        get
        {
            if (IsPressed)
                return _Axis;
            else
                return Vector2.zero;
        }
    }

    private int TouchId = -10;  // 조이스틱 터치 갯수를 제한할때 사용
    public Transform PointerTrans;

    private Vector3 CenterPosition;
    private Vector3 InnerPosition;

    private float Radius = 60.0f;
    private float InnerRadius = 10.0f;


    public void OnEnable()
    {
        UI_Camera = UICamera.mainCamera;
        if (UI_Camera == null)
        {
            Debug.LogError("JoyStic UI_Camera is NULL");
            return;
        }
        CenterPosition = UI_Camera.WorldToScreenPoint(this.SelfTransform.position);

        UIWidget widget = this.SelfComponent<UIWidget>();
        Radius = widget.width * 0.5f;       // 반지름
        InnerRadius = PointerTrans.gameObject.GetComponent<UIWidget>().width * 0.5f;

#if UNITY_ANDROID
        IsKeyBoardInput = false;
#endif
    }

    void OnPress(bool Pressed)
    {
        Debug.Log("Press");
        if (IsKeyBoardInput)
            return;
		
        if (Pressed) // 눌려짐
        {
            IsPressed = true;
            TouchId = UICamera.currentTouchID;
            InnerPosition = UICamera.currentTouch.pos;
        }
        else
        {
            IsPressed = false;
            InnerPosition = CenterPosition;
        }
        Movement();
    }

    void OnDrag()
    {
        Debug.Log("Drag : " + UICamera.currentTouch.pos);
        if (IsPressed)
        {
            InnerPosition = UICamera.currentTouch.pos;
            Movement();
        }
    }
    void Movement()
    {
        Vector3 MovePosition = InnerPosition - CenterPosition;
        if (MovePosition.magnitude < Radius * 0.2f) // magnitude 거리
        {
            MovePosition = Vector3.zero;
        }
        else if (MovePosition.magnitude >= (Radius - InnerRadius))
        {
            MovePosition = MovePosition.normalized * (Radius - InnerRadius);
        }

        PointerTrans.localPosition = MovePosition;

        if (NormalizedPower)
            MovePosition = MovePosition.normalized * Radius;

        _Axis.x = MovePosition.x / Radius;
        _Axis.y = MovePosition.y / Radius;

    }


#if UNITY_EDITOR
    private void Update()
    {
        Vector3 movePosition = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(movePosition != Vector3.zero)
        {
            IsKeyBoardInput = true;
            IsPressed = true;
            InnerPosition = CenterPosition + movePosition * Radius;
            Movement();
        }
        else
        {
            if(IsKeyBoardInput == true)
            {
                IsPressed = false;
                IsKeyBoardInput = false;
            }
        }
    }
#endif

}
