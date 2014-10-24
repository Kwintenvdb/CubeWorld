using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
	
	public GameObject Player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 vec = new Vector3(Player.transform.position.x,Player.transform.position.y,-35f);
		transform.position = vec;
	}
}