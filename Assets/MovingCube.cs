using UnityEngine;
using System.Collections;

public class MovingCube : MonoBehaviour {
	
	public Vector3 Direction;
	public float Speed = 30f;
	public float PushPullSpeed = 1.5f;
	
	public PauseMenu menu;
	
	private float _startSpeed;
	private bool _slowed = false;
	private bool _reversed = false;
	private float _timer;
	private float _reversedTimer;
	private float _closestDistance = 1000f;
	private GameObject _closestMagnet;
	
	private LineRenderer _lineRenderer;
	
	private bool _canMove = true;
	private Vector3 startPos;
	
	// Use this for initialization
	void Start () {
	
		//Direction.x = 0f;
		//Direction.y = 0f;
		//Direction.z = 0f;
		
		_startSpeed = Speed;
		
		_lineRenderer =  GetComponent<LineRenderer>();
		_lineRenderer.SetWidth(5f,5f);
		
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!menu.IsPaused())
		{
		// update position and rotation
		if(_canMove) transform.position += Speed * Direction * Time.deltaTime;
		_canMove = true;
		
		var velocity = Direction * Speed;
		transform.rotation = Quaternion.LookRotation(velocity);
		
		// find all magnets in the level
		var Magnets = GameObject.FindGameObjectsWithTag("Magnet");
				
		foreach(GameObject magnet in Magnets)
		{
			if(FindClosestMagnet(magnet)) _closestMagnet = magnet;
			(magnet.GetComponent("Halo") as Behaviour).enabled = false;
		}
		(_closestMagnet.GetComponent("Halo") as Behaviour).enabled = true;
		_closestDistance = 1000f;
		
		// check if mouse hits cubes;
		if(Input.GetMouseButton(0))
		{
			var magnetComp = _closestMagnet.GetComponent<Magnet>();
			if(!magnetComp.IsPullMagnet() && !magnetComp.IsPushMagnet()) ChangeDirection(_closestMagnet.transform.position);
			else if(magnetComp.IsPullMagnet()) PullPlayer(_closestMagnet.transform.position);
			else if(magnetComp.IsPushMagnet()) PushPlayer(_closestMagnet.transform.position);
			
			_lineRenderer.SetVertexCount(2);
			_lineRenderer.SetPosition(0,transform.position);
			_lineRenderer.SetPosition(1,_closestMagnet.transform.position);
		}
		else
		{
			_lineRenderer.SetVertexCount(0);
		}
		
		HandleMovement();
		}
	}
	
	public void ChangeDirection(Vector3 magnetPos) {
	
		Vector3 distanceVector = magnetPos - transform.position;	
		var distance = Vector3.Distance(transform.position, magnetPos);
		
		//Debug.Log(distanceVector);
		Direction += distanceVector.normalized/(distance/1.75f);
		Direction.Normalize();
		Direction.z = 0;
	}
	
	public void PullPlayer(Vector3 magnetPos) {
	
		Vector3 distanceVector = magnetPos - transform.position;
		var distance = Vector3.Distance(transform.position, magnetPos);
		
		_canMove = false;
		transform.position += (distanceVector.normalized * PushPullSpeed);
		transform.position = new Vector3(transform.position.x,transform.position.y,startPos.z);
	}
	
	public void PushPlayer(Vector3 magnetPos) {
	
		Vector3 distanceVector = magnetPos - transform.position;
		var distance = Vector3.Distance(transform.position, magnetPos);
		
		_canMove = false;
		transform.position -= (distanceVector.normalized * PushPullSpeed);
		transform.position = new Vector3(transform.position.x,transform.position.y,startPos.z);
	}
	
	public void SlowDown(bool slow) {
		
		_slowed = slow;
	}
	
	public void ReverseDirection(bool reverse) {
	
		_reversed = reverse;
		Direction *= -1;
	}
	
	public void HandleMovement() {
		
		// Slowdown
		if(_slowed)
		{
			_timer += Time.deltaTime;
			Speed = _startSpeed / 2f;
		}
		else Speed = _startSpeed;
		if(_timer >= 1.5f)
		{
			SlowDown(false);
			_timer = 0f;
		}
		
		//Reversed direction
		if(_reversed)
		{
			_reversedTimer += Time.deltaTime;	
		}
		if(_reversedTimer >= 1.5f)
		{
			ReverseDirection(false);
			_reversedTimer = 0f;
		}
	}
	
	public void OnTriggerEnter(Collider other) {
	
		if(other.gameObject.tag == "Level")
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if(other.gameObject.tag == "PickupSlow")
		{
			SlowDown(true);
			Destroy(other.gameObject);			
		}
		
		if(other.gameObject.tag == "PickupReverse")
		{
			ReverseDirection(true);
			Destroy(other.gameObject);	
		}
	}
	
	bool FindClosestMagnet(GameObject mag) {

		var magnetPos = mag.transform.position;
		
		var distance = Vector3.Distance(transform.position, magnetPos);
		if(distance <= _closestDistance)
		{
			_closestDistance = distance;
			return true;
		}
		else return false;
	}
}
