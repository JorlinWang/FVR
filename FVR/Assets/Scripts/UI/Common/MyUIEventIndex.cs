using UnityEngine;
using System.Collections;

public class MyUIEventIndex : MonoBehaviour {
	public delegate void EventHandler();
	public event EventHandler Listener;

	public void Invoke(){
		if (Listener != null)
			Listener.Invoke ();
		else
			Debug.LogError (string.Format("The Event in {0} is null, please check it.", gameObject.name));
	}
}
