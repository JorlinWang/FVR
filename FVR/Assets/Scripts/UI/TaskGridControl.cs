using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskGrid {
	public string bg;
	public string title;
	public string content;
	public int index;

	public TaskGrid(string bg, string title, string content, int index) {
		this.bg = bg;
		this.title = title;
		this.content = content;
		this.index = index;
	}
	public TaskGrid(){}
}

public class TaskGridControl : MonoBehaviour {
	private GameObject GridPrefab;
	private UIGrid uiGrid;
	public TaskGrid[] taskGrid;
	// Use this for initialization
	void Start () {
		GridPrefab = Resources.Load<GameObject>("UIPrefabs/Grid");
		uiGrid = GetComponent<UIGrid>();
		taskGrid = SeriaOrDeSeria.DeSerialzeXML (AllDataPath.Instance.TaskXMLPath, typeof(TaskGrid[])) as TaskGrid[];
		for (int i = 0; i < taskGrid.Length; i++) {
			GameObject obj = Instantiate<GameObject>(GridPrefab);
			obj.GetComponent<TaskGridMono>().Primary(taskGrid[i]);
			obj.transform.SetParent(transform);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one;
		}
		uiGrid.repositionNow = true;
	}
	
}
