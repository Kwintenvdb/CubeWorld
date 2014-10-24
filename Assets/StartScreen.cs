using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	
	public bool winscreen = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(winscreen)
			{
				Application.LoadLevel("startscreen");	
			}
			else
			{
				Application.LoadLevel("Level1");	
			}
		}
	
	}
}
