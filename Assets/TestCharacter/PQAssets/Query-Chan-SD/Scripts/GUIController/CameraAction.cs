using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraAction : MonoBehaviour {

	[SerializeField]
	GameObject queryChan;

	UIButton CharacterClick = null;
	UIButton CharacterClick_Inven = null;
	float startPosX = 0.0f;
	//float startPosY = 0.0f;
	
	float rotatePosX = 0.0f;
	//float rotatePosY = 0.0f;
	
	//float beforePos = 0.0f;

	public bool click = false;

	private void Awake()
	{
		
		CharacterClick = gameObject.transform.parent.FindChild("UI Root").FindChild("Character_RenderPanel").FindChild("Character_Render").GetComponent<UIButton>();
		//CharacterClick = transform.Find("Character_Render").GetComponent<UIButton>();

		CharacterClick_Inven = gameObject.transform.parent.FindChild("UI Root").FindChild("PF_UI_MYROOM").FindChild("EquipPanel").FindChild("My_Information_Character").GetComponent<UIButton>();
		//EventDelegate.Add(CharacterClick new EventDelegate(this, "CharacterClickOn"));
		//EventDelegate.Add(CharacterClick_Inven.onClick, new EventDelegate(this, "CharacterClickOn"));
	}


	void Start()
	{
		//EventTrigger trigger = gameObject.transform.parent.FindChild("UI Root").FindChild("Character_RenderPanel").FindChild("Character_Render").GetComponent<EventTrigger>();
		//EventTrigger.Entry entry = new EventTrigger.Entry();
		//entry.eventID = EventTriggerType.Drag;
		//entry.callback.AddListener((data) => { CharacterDrag((PointerEventData)data); });
		//trigger.triggers.Add(entry);
	}

	public void CharacterDrag(PointerEventData data)
	{
		Debug.Log("Drag");
		click = true;
	}
	public void OnMouseDrag()
	{
		Debug.Log("Drag");
		click = true;
	}

	void Update () {

		CameraRotateDevice();
		cameraRotateEditor();

	}


	void CharacterClickOn()
	{
	//	click = true;
	}

	void CameraRotateDevice(){

		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			// toutch start
			if(touch.phase == TouchPhase.Began){
				startPosX =  Input.GetTouch(0).position.x;
				//startPosY = Input.GetTouch(0).position.y;
			}
			// touch moving
			else if(touch.phase == TouchPhase.Moved){
				rotatePosX = (startPosX - Input.mousePosition.x);
				//rotatePosY = (startPosY - Input.mousePosition.y);
				queryChan.transform.localEulerAngles += new Vector3 (0,rotatePosX, 0);
				startPosX = Input.mousePosition.x;
				//startPosY = Input.mousePosition.y;
			}
		}

	}


	void cameraRotateEditor(){

		 if (Input.GetMouseButtonDown(0)){
			startPosX =  Input.mousePosition.x;
			//startPosY = Input.mousePosition.y;
			//click = true;
		}
		
		if(click){			
			rotatePosX = (startPosX - Input.mousePosition.x);
			//rotatePosY = (startPosY - Input.mousePosition.y);
			queryChan.transform.localEulerAngles += new Vector3 (0,rotatePosX, 0);
			startPosX = Input.mousePosition.x;
			//startPosY = Input.mousePosition.y;
		}
		
		 if (Input.GetMouseButtonUp(0)){
			click = false;
		}

	}
	
	
}
