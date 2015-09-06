using UnityEngine;
using System.Collections;

[System.Serializable]
public class TimeData {
	public float hour;
	public float minit;
	public float second;

	public int Hour {
		get {return (int)hour;}
	}
	public int Minite {
		get {return (int)minit;}
	}
	public int Second {
		get{return (int)second;}
	}

	public TimeData(){
	}

	public TimeData(float hour, float minit, float second) {
		this.hour = hour + minit / 60.0f + second / 3600.0f;
		this.minit = minit + second / 60.0f;
		this.second = second;
	}
	public void UpdateTime(float hour, float minit, float second){
		this.hour += hour;
		this.hour = this.hour % 24;
		this.minit += minit;
		this.minit = this.minit % 60;
		this.second += second;
		this.second = this.second % 60;
	}
	public void CloneValue (TimeData other) {
		this.hour = other.hour;
		this.minit = other.minit;
		this.second = other.second;
	}
	public override string ToString ()
	{
		return string.Format ("{0}:{1}:{2}", Hour, Minite, Second);
	}
}

public class Clock : MonoBehaviour {
	public Transform Hour;
	public Transform Minite;
	public UILabel label;
	public float TimeScale;

	public TimeData PrimaryTime;
	public TimeData CurTime;

	private float hourValue;
	private float miniteValue;
	private float SecondValue;

	private float OldUsedTime;
	private float TimeDelta;

	// Use this for initialization
	void Start () {
		CurTime = new TimeData (PrimaryTime.hour, PrimaryTime.minit, PrimaryTime.second);
		OldUsedTime = 0;
		TimeDelta = OldUsedTime;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Caculate ();
	}
	void Caculate(){
		TimeDelta = (Time.time - OldUsedTime) * TimeScale;
		SecondValue = TimeDelta;
		miniteValue = TimeDelta / 60.0f;
		hourValue = TimeDelta / (60.0f * 60.0f);
		CurTime.UpdateTime (hourValue, miniteValue, SecondValue );
		Hour.localEulerAngles = new Vector3 (Hour.localEulerAngles.x, Hour.localEulerAngles.y, -((CurTime.hour % 12f) / 12.0f) * 360);
		Minite.localEulerAngles = new Vector3 (Minite.localEulerAngles.x, Minite.localEulerAngles.y, -((CurTime.minit % 60f) / 60.0f) * 360);
		OldUsedTime = Time.time;
		label.text = CurTime.ToString();
	}

//	void OnGUI(){
//		GUILayout.Label (string.Format("Now time: {0}:{1}:{2}", CurTime.Hour, CurTime.Minite, CurTime.Second));
//	}
}


















