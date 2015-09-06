using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.VR;
using System.Collections.Generic;
using System;

public enum UIItemsState{
	Normal,
	Hover,
	Pressed
}

public class RowBase {
	public bool RowUse;
	public int y;
	public int count;

	public RowBase(bool RowUse, int count) {
		this.RowUse = RowUse;
		y = 0;
		this.count = count;
	}
	public RowBase() {
		RowUse = false;
		y = 0;
		count = 0;
	}
}

public class RowItems<T> : RowBase {
	public T[] items;


	public RowItems(bool RowUse, int count) : base(RowUse, count){
		items = new T[count];
	}
	
}
public class UIItemsMatrix {

	public ArrayList itemMatrix;
	public int x;
//	public RowBase ob;
	public static UIItemsMatrix instance;
	public RowItems<UIButton> ButtomDownUI;
	public RowItems<UIButton> ButtomUpUI;

//	public void AdjustRowUse(int x, bool value) {
////		CheckItemClass (x);
//		(itemMatrix [x] as RowItems<UIButton>).RowUse = value;
////		ob.RowUse = value;
//	}
	public void AddUI(RowItems<UIButton> UI){
		itemMatrix.Add (UI);
	}
	public void DeleteUI(RowItems<UIButton> UI) {
		itemMatrix.Remove (UI);
	}  
	public void UpdateButtomDownUI(){
		GameObject[] GirdBtns = DownPanelControl._instance.ShowGridBtnObjs.ToArray();
		for (int i = 0; i < GirdBtns.Length; i++) {
			ButtomDownUI.items[i] = GirdBtns[i].GetComponent<UIButton>();
		}
	}
	public UIItemsMatrix () {
		instance = this;

		itemMatrix = new ArrayList ();
		x = 0;

		GameObject[] GirdBtns = DownPanelControl._instance.ShowGridBtnObjs.ToArray();
		ButtomDownUI = new RowItems<UIButton> (true,GirdBtns.Length);
		UpdateButtomDownUI ();
		AddUI (ButtomDownUI);

		ButtomUpUI = new RowItems<UIButton> (true, 4);
		AddUI (ButtomUpUI);
		ButtomUpUI.items [0] = GameObject.Find ("UpperPanel/1Btn").GetComponent<UIButton>();
		ButtomUpUI.items [1] = GameObject.Find ("UpperPanel/1Btn (1)").GetComponent<UIButton>();
		ButtomUpUI.items [2] = GameObject.Find ("UpperPanel/1Btn (2)").GetComponent<UIButton>();
		ButtomUpUI.items [3] = GameObject.Find ("UpperPanel/1Btn (3)").GetComponent<UIButton>();

	}
	public void Up() {
		if (x < itemMatrix.Count - 1) {
			int tempx = x;
			RowItems<UIButton> button = (itemMatrix[x] as RowItems<UIButton>);
			//button.items[button.y].state = UIButtonColor.State.Normal;
			LightItem(UIItemsState.Normal);
			do {
				if(++x > itemMatrix.Count - 1) {
					x = tempx;
					break;
				}
//				CheckItemClass(x);
				button = (itemMatrix[x] as RowItems<UIButton>);
			} while(!button.RowUse);
			LightItem(UIItemsState.Hover);
		}

	}
	public void Down(){
		if (x > 0) {
			int tempx = x;
			RowItems<UIButton> button = (itemMatrix[x] as RowItems<UIButton>);
			//button.items[button.y].state = UIButtonColor.State.Normal;
			LightItem(UIItemsState.Normal);
			do {
				if(--x < 0) {
					x = tempx;
					break;
				}
				button = (itemMatrix[x] as RowItems<UIButton>);
			} while(!button.RowUse);
			LightItem(UIItemsState.Hover);
		}
	}
	public void Left(){
		RowItems<UIButton> button = (itemMatrix[x] as RowItems<UIButton>);
		if (button.y > 0) {
			//button.items[button.y].state = UIButtonColor.State.Normal;
			LightItem(UIItemsState.Normal);
			button.y--;
			LightItem(UIItemsState.Hover);
		}
		if (x == 0 && button.y == 0) {
			LightItem(UIItemsState.Normal);
			int index = DownPanelControl._instance.ShowIndexs[0] - 1;
			if(index >= 0) {
				DownPanelControl._instance.AdjustShowGrids(index);
			}
			LightItem(UIItemsState.Hover);
		}
	}
	public void Right(){
		RowItems<UIButton> button = (itemMatrix[x] as RowItems<UIButton>);
		if (button.y < button.count - 1) {
			//button.items[button.y].state = UIButtonColor.State.Normal;
			LightItem(UIItemsState.Normal);
			button.y++;
			LightItem(UIItemsState.Hover);
		}
		if (x == 0 && button.y == button.count - 1) {
			LightItem(UIItemsState.Normal);
			int index = DownPanelControl._instance.ShowIndexs[DownPanelControl._instance.ShowIndexs.Length - 1] + 1;
			if(index <= DownPanelControl._instance.GridBtnObjs.Length - 1) {
				DownPanelControl._instance.AdjustShowGrids(index);
			}
			LightItem(UIItemsState.Hover);
		}
	}
	public void LightItem(UIItemsState state){
		if (x != 0) {
			switch (state) {
			case UIItemsState.Hover:
				(itemMatrix [x] as RowItems<UIButton>).items [(itemMatrix [x] as RowItems<UIButton>).y].state = UIButtonColor.State.Hover;
				break;
			case UIItemsState.Pressed:
				(itemMatrix [x] as RowItems<UIButton>).items [(itemMatrix [x] as RowItems<UIButton>).y].state = UIButtonColor.State.Pressed;
				break;
			case UIItemsState.Normal:
				(itemMatrix [x] as RowItems<UIButton>).items [(itemMatrix [x] as RowItems<UIButton>).y].state = UIButtonColor.State.Normal;
				break;
			}
//			Debug.Log("Light");
//			Debug.Log ("y1: " + (itemMatrix [x] as RowItems<UIButton>).y);
		} else {
			switch (state) {
			case UIItemsState.Hover:
				(itemMatrix [x] as RowItems<UIButton>).items [(itemMatrix [x] as RowItems<UIButton>).y].GetComponentInChildren<UITexture>().color = Color.red;
				break;
			case UIItemsState.Normal:
				(itemMatrix [x] as RowItems<UIButton>).items [(itemMatrix [x] as RowItems<UIButton>).y].GetComponentInChildren<UITexture>().color = Color.white;
				break;
			}
		}
	}
}

public class UIButtonXInputControl : MonoBehaviour {
	PlayerIndex playerIndex;
	GamePadState preState;
	GamePadState state;
	bool playerIndexSet = false;
	UIItemsMatrix temp;
	Transform TargetCamera;
	bool ShowMainPanel = true;

	public TweenAlpha MainPanel;
	public UILabel MainPanelTwist;
	public float XSencitive = 1;
	public float YSencitive = 1;
	public float HighestAngle = -80;
	public float LowestAngle = 80;

	public static UIButtonXInputControl _instance;


	void Start(){
		_instance = this;
		temp = new UIItemsMatrix ();
//		Debug.Log ("Start");
//		(temp.itemMatrix [0] as RowItems<UIButton>).items [1].state = UIButtonColor.State.Hover;
		temp.LightItem (UIItemsState.Hover);
		TargetCamera = GameObject.Find ("FPSController/Main Camera").transform;

//		Debug.Log (HighestAngle + " " + LowestAngle);
	}
	public void SelectTargetCamera(Transform target){
		TargetCamera = target;
	}
	public void SwitchTwistButton(){
		MainPanelTwist.enabled = ShowMainPanel;
	}
	void Update(){
		preState = state;
		state = GamePad.GetState (playerIndex);
		if (!playerIndexSet || !preState.IsConnected)
		{
			for (int i = 0; i < 4; ++i)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}
		if (!ShowMainPanel) {
			if ((preState.DPad.Up == ButtonState.Released && state.DPad.Up == ButtonState.Pressed) || Input.GetKeyDown(KeyCode.I)) {
				temp.Up ();
//			Debug.Log("Up");
			}
			if ((preState.DPad.Down == ButtonState.Released && state.DPad.Down == ButtonState.Pressed) || Input.GetKeyDown(KeyCode.K)) {
				temp.Down ();
//			Debug.Log("Down");
			}
			if ((preState.DPad.Left == ButtonState.Released && state.DPad.Left == ButtonState.Pressed) || Input.GetKeyDown(KeyCode.J)){
				temp.Left ();
//			Debug.Log("Left");
			}
			if ((preState.DPad.Right == ButtonState.Released && state.DPad.Right == ButtonState.Pressed) || Input.GetKeyDown(KeyCode.L)){
				temp.Right ();
//			Debug.Log("Right");
			}

			if ((preState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed) || Input.GetMouseButtonDown(0)) {
				temp.LightItem (UIItemsState.Pressed);
				if (temp.itemMatrix [temp.x] is RowItems<UIButton>) {
					RowItems<UIButton> button = temp.itemMatrix [temp.x] as RowItems<UIButton>;
//				Debug.Log(temp.x + " " + temp.ob.y);
					button.items [button.y].gameObject.GetComponent<MyUIEventIndex> ().Invoke ();
				}
			}
			if ((preState.Buttons.A == ButtonState.Pressed && state.Buttons.A == ButtonState.Released) || Input.GetMouseButtonUp(0)) {
				if (Time.frameCount > 1)
					temp.LightItem (UIItemsState.Hover);
			}
		}
		if ((preState.Buttons.Y == ButtonState.Released && state.Buttons.Y == ButtonState.Pressed) || Input.GetKeyDown(KeyCode.Y)) {
			if(Time.frameCount > 1) {
				if(ShowMainPanel) {
					ShowMainPanel = !ShowMainPanel;
					MainPanel.PlayForward();
					//MainPanelTwist.enabled = false;
				}else {
					ShowMainPanel = !ShowMainPanel;
					MainPanel.PlayReverse();
					//MainPanelTwist.enabled = true;
				}
			}
		}
		if (!VRDevice.isPresent) {
			if (state.ThumbSticks.Right.X != 0 || state.ThumbSticks.Right.Y != 0) {
				if (TargetCamera != null) {
					if ((TargetCamera.localEulerAngles.x > HighestAngle || TargetCamera.localEulerAngles.x < LowestAngle)
						|| (TargetCamera.eulerAngles.x < HighestAngle && state.ThumbSticks.Right.Y < 0 && TargetCamera.eulerAngles.x > HighestAngle - 10)
						|| (TargetCamera.eulerAngles.x > LowestAngle && state.ThumbSticks.Right.Y > 0 && TargetCamera.eulerAngles.x < LowestAngle + 10)) {
						TargetCamera.Rotate (Vector3.right, -state.ThumbSticks.Right.Y * YSencitive * Time.deltaTime);
					}
					TargetCamera.parent.Rotate (Vector3.up, state.ThumbSticks.Right.X * XSencitive * Time.deltaTime);
					TargetCamera.rotation = Quaternion.Euler (new Vector3 (TargetCamera.eulerAngles.x, TargetCamera.eulerAngles.y, 0));
				} else {
					Debug.Log ("TargetCamera is null, please check.");
				}
			}
		}
	}
}
