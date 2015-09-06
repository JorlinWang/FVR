using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DownPanelControl : MonoBehaviour {
	string path;
	public GridBtn[] grids;
	public GameObject GridBtnPrefab;
	public GameObject DownPanelRepository;

	public GameObject[] GridBtnObjs;
	public List<GameObject> ShowGridBtnObjs;
	public int[] ShowIndexs;
	private int[] DefaultShowIndexs;
	public int MaxPerLine;
	private UIGrid GridBase;

	public static DownPanelControl _instance;

	// Use this for initialization
	void Awake () {
		_instance = this;
		path = Application.streamingAssetsPath + "/GridBtn.xml";
		PrimaryGridBtn ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PrimaryXML(){
		string GridBtnImgPath = "GridBtnImg/";
		GridBtn[] grids = new GridBtn[10];
		grids [0] = new GridBtn (GridBtnImgPath + "1");
		grids [1] = new GridBtn (GridBtnImgPath + "2");
		grids [2] = new GridBtn (GridBtnImgPath + "3");
		grids [3] = new GridBtn (GridBtnImgPath + "4");
		grids [4] = new GridBtn (GridBtnImgPath + "5");
		grids [5] = new GridBtn (GridBtnImgPath + "6");
		grids [6] = new GridBtn (GridBtnImgPath + "7");
		grids [7] = new GridBtn (GridBtnImgPath + "8");
		grids [8] = new GridBtn (GridBtnImgPath + "9");
		grids [9] = new GridBtn (GridBtnImgPath + "10");

		SeriaOrDeSeria.SerialzeXML<GridBtn[]> (path, grids);
	}
	public void PrimaryGridBtn(){
		GridBase = GetComponent<UIGrid> ();
		MaxPerLine = GridBase.maxPerLine;
		DefaultShowIndexs = new int[]{0, 1, 2, 3, 4, 5};
		ShowGridBtnObjs = new List<GameObject> ();

		PrimaryXML ();
		grids = SeriaOrDeSeria.DeSerialzeXML (path, typeof(GridBtn[])) as GridBtn[];
		GridBtnObjs = new GameObject[grids.Length];
		for (int i = 0; i < grids.Length; i++) {
			GameObject ob = Instantiate(GridBtnPrefab) as GameObject;
			ob.transform.GetChild(0).GetComponent<UITexture>().mainTexture = Resources.Load<Texture>(grids[i].ImgPath);
			ob.name = GridBtnPrefab.name + i.ToString();
			GridBtnObjs[i] = ob;
			ob.transform.SetParent(DownPanelRepository.transform);
			ob.transform.position = Vector3.zero;
			ob.transform.localScale = Vector3.one;
		}
		GridBtnObjs[0].GetComponent<MyUIEventIndex>().Listener += Test1;
		GridBtnObjs[1].GetComponent<MyUIEventIndex>().Listener += Test2;
		GridBtnObjs[2].GetComponent<MyUIEventIndex>().Listener += Test3;
		GridBtnObjs[3].GetComponent<MyUIEventIndex>().Listener += Test4;
		GridBtnObjs[4].GetComponent<MyUIEventIndex>().Listener += Test5;
		GridBtnObjs[5].GetComponent<MyUIEventIndex>().Listener += Test6;
		GridBtnObjs[6].GetComponent<MyUIEventIndex>().Listener += Test7;
		GridBtnObjs[7].GetComponent<MyUIEventIndex>().Listener += Test8;
		GridBtnObjs[8].GetComponent<MyUIEventIndex>().Listener += Test9;
		GridBtnObjs[9].GetComponent<MyUIEventIndex>().Listener += Test10;

		AdjustShowGrids(0, true);
	}
	public void AdjustShowGrids(int index, bool Default = false){

		if (Default) {
			ShowIndexs = DefaultShowIndexs;
		} else {
			if (index < ShowIndexs [0]) {
				for (int i = ShowIndexs.Length - 1; i >= 0; i--) {
					if (i > 0)
						ShowIndexs [i] = ShowIndexs [i - 1];
					else
						ShowIndexs [i] = index;
				}
			}
			if (index > ShowIndexs [ShowIndexs.Length - 1]) {
				for (int i = 0; i < ShowIndexs.Length; i++) {
					if (i < ShowIndexs.Length - 1)
						ShowIndexs [i] = ShowIndexs [i + 1];
					else
						ShowIndexs [i] = index;
				}
			}
		}
		foreach (GameObject obj in ShowGridBtnObjs) {
//			obj.GetComponent<>();
			obj.transform.SetParent(DownPanelRepository.transform);
//			obj.transform.localScale = Vector3.zero;
			obj.transform.localPosition = Vector3.zero;

		}
		ShowGridBtnObjs.Clear();

		foreach (int i in ShowIndexs) {
			ShowGridBtnObjs.Add(GridBtnObjs[i]);
			GridBtnObjs[i].transform.SetParent(transform);
			GridBtnObjs[i].transform.localPosition = Vector3.zero;
			GridBtnObjs[i].transform.localScale = Vector3.one;
		}
		GridBase.repositionNow = true;
		if(!Default)
			UIItemsMatrix.instance.UpdateButtomDownUI ();
	}











	public void Test1(){
		Debug.Log ("1");
	}
	public void Test2(){
		Debug.Log ("2");
	}
	public void Test3(){
		Debug.Log ("3");
	}
	public void Test4(){
		Debug.Log ("4");
	}
	public void Test5(){
		Debug.Log ("5");
	}
	public void Test6(){
		Debug.Log ("6");
	}
	public void Test7(){
		Debug.Log ("7");
	}
	public void Test8(){
		Debug.Log ("8");
	}
	public void Test9(){;
		Debug.Log ("9");
	}
	public void Test10(){
		Debug.Log ("10");
	}


}









