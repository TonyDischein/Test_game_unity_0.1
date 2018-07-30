using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform EndPoint;
    public Transform[] MovePoints;

    public float Speed;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, Time.deltaTime * Speed);
    }
}
