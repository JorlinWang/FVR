using UnityEngine;
using System.Collections;

public class TestUse : MonoBehaviour {
	// Use this for initialization
	void Start () {
		SeriaOrDeSeria.SerialzeXML<Test> (Application.streamingAssetsPath + "/wocao.xml", new Test());
		Test b = SeriaOrDeSeria.DeSerialzeXML (Application.streamingAssetsPath + "/wocao.xml", typeof(Test)) as Test;
		Debug.Log (b.aaa);
	}

}
public class Test{
	public int aaa;
	public Test(){
		aaa = 11;
	}
}
