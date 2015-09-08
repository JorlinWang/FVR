using UnityEngine;
using System.Collections;

public class UIPanelMovie : MonoBehaviour {
	public MovieTexture texture;
	// Use this for initialization
	void Start () {
		GetComponent<UITexture>().mainTexture = texture;
		texture.Play ();
		texture.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
