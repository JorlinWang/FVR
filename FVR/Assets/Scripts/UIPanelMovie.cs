using UnityEngine;
using System.Collections;

public class testmovie : MonoBehaviour {
	public MovieTexture texture;
	// Use this for initialization
	void Start () {
		GetComponent<UITexture>().mainTexture = texture;
		texture.Play ();
		texture.loop = true;
	}
}
