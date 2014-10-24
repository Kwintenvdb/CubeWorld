using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	
	public bool pullMagnet = false;
	public bool pushMagnet = false;
	
	// Use this for initialization
	void Start () {
	
		if(pullMagnet) pushMagnet = false;
		if(pushMagnet) pullMagnet = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	
	public bool IsPullMagnet() {
	
		return pullMagnet;
	}
	
	public bool IsPushMagnet() {
		
		return pushMagnet;	
	}
}
