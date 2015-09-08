using UnityEngine;
using System.Collections;

public class PenShui : MonoBehaviour {
	public ParticleSystem particle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(particle.isPlaying)
				particle.Stop();
			else
				particle.Play();
		}
	}
}
