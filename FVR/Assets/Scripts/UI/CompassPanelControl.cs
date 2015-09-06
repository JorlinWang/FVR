using UnityEngine;
using System.Collections;

public class CompassPanelControl : MonoBehaviour {
	public enum Weather : int{
		Sun = 0,
		Snow = 1,
		Night = 2,
		LightRain = 3,
		Cloudy = 4,
		ThunderRain = 5,
		DeFault
	}
	[SerializeField]
	private Weather weather;

	public UITexture weatherTex;
	public UITexture Compass;
	public Transform CompassIndex;
	public UILabel WindLabel;
	public Transform FpsCamera;

	// Use this for initialization
	void Start () {
		AdjustWeather (weather);
	}
	public void AdjustWeather(Weather weather){
		this.weather = weather;
		switch (this.weather) {
		case Weather.Sun:
			weatherTex.mainTexture = Resources.Load<Texture>("Weather/Sun");
			break;
		case Weather.Snow:
			weatherTex.mainTexture = Resources.Load<Texture>("Weather/Snow");
			break;
		case Weather.Night:
			weatherTex.mainTexture = Resources.Load<Texture>("Weather/Night");
			break;
		case Weather.LightRain:
			weatherTex.mainTexture = Resources.Load<Texture>("Weather/LightRain");
			break;
		case Weather.Cloudy:
			weatherTex.mainTexture = Resources.Load<Texture>("Weather/Cloudy");
			break;
		case Weather.ThunderRain:
			weatherTex.mainTexture = Resources.Load<Texture>("Weather/ThunderRain");
			break;
		}
	}
	void Update(){
		//Update CompassIndexRotation
		CompassIndex.eulerAngles = new Vector3 (0,0,-FpsCamera.eulerAngles.y);
	}
	public Weather GetWeather(){
		return weather;
	}
}
