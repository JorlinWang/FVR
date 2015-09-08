using UnityEngine;
using System.Collections;

public class AllDataPath
{
	public string TaskXMLPath;

	private static AllDataPath instance;
	public static AllDataPath Instance {
		get {
			if(instance == null)
				instance = new AllDataPath();
			return instance;
		}
	}

	public AllDataPath () {
		TaskXMLPath = Application.streamingAssetsPath + "/TaskGrid.xml";
	}
}

