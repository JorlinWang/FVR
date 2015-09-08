using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class SeriaTool : Editor
{
	[MenuItem("Primary/TaskGrid")]
	public static void PrimaryTaskGrid(){
		List<TaskGrid> tgrids = new List<TaskGrid> ();
		tgrids.Add (new TaskGrid("TaskGridTex/1", "任务一", "士大夫似的犯得上大师傅", 0));
		tgrids.Add (new TaskGrid("TaskGridTex/2", "任务二", "士大夫似的犯得上大师傅", 1));
		tgrids.Add (new TaskGrid("TaskGridTex/3", "任务三", "士大夫似的犯得上大师傅", 2));
		tgrids.Add (new TaskGrid("TaskGridTex/4", "任务四", "士大夫似的犯得上大师傅", 3));
		tgrids.Add (new TaskGrid("TaskGridTex/1", "任务一", "士大夫似的犯得上大师傅", 4));
		tgrids.Add (new TaskGrid("TaskGridTex/1", "任务一", "士大夫似的犯得上大师傅", 5));
		tgrids.Add (new TaskGrid("TaskGridTex/1", "任务一", "士大夫似的犯得上大师傅", 6));
		tgrids.Add (new TaskGrid("TaskGridTex/1", "任务一", "士大夫似的犯得上大师傅", 7));
		TaskGrid[] temp = tgrids.ToArray ();
		SeriaOrDeSeria.SerialzeXML<TaskGrid[]> (AllDataPath.Instance.TaskXMLPath, temp);
	}
}

