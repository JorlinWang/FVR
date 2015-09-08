using UnityEngine;
using System.Collections;

public class MyNGUIEvent : MonoBehaviour {
	public TweenPosition tween;
	public delegate void myEevent();
	public event myEevent click;

	public void Start(){
		click += GameObject.Find ("TaskWindow").GetComponent<TweenScale>().PlayForward;
		click += GameObject.Find ("TaskWindow").GetComponent<TweenPosition>().PlayForward;
	}

	public void ForwardInvoke(){
		if (tween.direction == AnimationOrTween.Direction.Forward) {
			click.Invoke();
		}
	}
}
