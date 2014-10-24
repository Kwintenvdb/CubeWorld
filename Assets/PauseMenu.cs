using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	private bool isPause = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Escape))
   		{
      		if(!isPause) isPause = true;
      		if(isPause)
        		Time.timeScale = 0;
		}
	}
	
	public bool IsPaused() {
	
		return isPause;
	}
	
	void OnGUI () {
		
		if(isPause)
		{
			if(GUI.Button(new Rect(Screen.width/2,100,150,50), "Resume")) 
			{
				isPause = !isPause;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(Screen.width/2,170,150,50), "Go to level select")) 
			{
				Application.LoadLevel("levelscreen");
				if(GUI.Button(new Rect(Screen.width/2,100,150,50), "Level1"))
				{
					Application.LoadLevel("Level1");	
				}
			}
			
			if(GUI.Button(new Rect(Screen.width/2,240,150,50), "Exit"))
			{
				Application.Quit();	
			}
		}
	}
}