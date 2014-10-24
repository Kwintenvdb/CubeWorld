using UnityEngine;
using System.Collections;

public class LevelScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {

		if(GUI.Button(new Rect(Screen.width/2-75,100,150,50), "Level 1")) 
		{
			Application.LoadLevel("Level1");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-75,170,150,50), "Level 2")) 
		{
			Application.LoadLevel("Level2");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-75,240,150,50), "Level 3"))
		{
			Application.LoadLevel("Level3");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-75,310,150,50), "Level 4"))
		{
			Application.LoadLevel("Level4");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-75,380,150,50), "Level 5"))
		{
			Application.LoadLevel("Level5");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-75,450,150,50), "Level 6"))
		{
			Application.LoadLevel("Level6");
		}
		
		if(GUI.Button(new Rect(Screen.width/2-75,520,150,50), "Level 7"))
		{
			Application.LoadLevel("Level7");
		}
	}

}
