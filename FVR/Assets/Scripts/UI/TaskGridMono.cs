using UnityEngine;
using System.Collections;

public class TaskGridMono : MonoBehaviour {
	public UITexture bg;
	public UILabel title;
	public UILabel content;
	public int index;

	public void Primary(TaskGrid taskGrid){
		this.bg.mainTexture = Resources.Load<Texture>(taskGrid.bg);
		this.title.text = taskGrid.title;
		this.content.text = taskGrid.content;
		this.index = taskGrid.index;
	}
	void OnClick(){
		switch (index) {
		case 0:
			Debug.Log("任务1");
			break;
		case 1:
			Debug.Log("任务2");
			break;
		case 2:
			Debug.Log("任务3");
			break;
		case 3:
			Debug.Log("任务4");
			break;
		case 4:
			Debug.Log("任务5");
			break;
		case 5:
			Debug.Log("任务6");
			break;
		case 6:
			Debug.Log("任务7");
			break;
		case 7:
			Debug.Log("任务8");
			break;

		}
	}
}
