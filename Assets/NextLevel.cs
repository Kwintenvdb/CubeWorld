using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	
	public string nextLevel;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnTriggerEnter(Collider other) {
			
		if(other.gameObject.tag == "Player")
			Application.LoadLevel(nextLevel);
	}
}
