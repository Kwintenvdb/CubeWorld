using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	//public GameObject ObjectToFollow;
	
	public Transform target;
	float distance = 0.5f;
	float height = 0.0f;
	float damping = 1.5f;
	bool smoothRotation = true;
	float rotationDamping = 30.0f;
	private Vector3 startPos;
	//
	//// Use this for initialization
	void Start () {
	
		startPos = transform.position;
	}
	//
	//// Update is called once per frame
	//void Update () {
	//
	//	Vector3 position = ObjectToFollow.transform.position;
	//	position.z = transform.position.z;
	//	transform.position = position;
	//}
	
	void Update () {
		
		var wantedPosition = target.TransformPoint(0, height, -distance);
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		
		Vector3 upVec = new Vector3(0,1,0);
		
		if (smoothRotation) {
			var wantedRotation = Quaternion.LookRotation(target.position - transform.position, upVec);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt (target, target.up);
		
		Vector3 newPos = new Vector3(transform.position.x, transform.position.y, startPos.z);
		transform.position = newPos;
	}
}