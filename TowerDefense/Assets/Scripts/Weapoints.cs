using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapoints : MonoBehaviour {

    public GameObject point_0;
    public GameObject point_1;
    public GameObject point_2;
    public GameObject point_3;

    Transform[] AllPoint = new Transform[4];

    private Vector3 TargetPoint;

    private int i = 0;

    public float Speed = 5f;

    // Use this for initialization
    void Start () {
        point_0 = GameObject.FindGameObjectWithTag("MovePoint1");
        point_1 = GameObject.FindGameObjectWithTag("MovePoint2");
        point_2 = GameObject.FindGameObjectWithTag("MovePoint3");
        point_3 = GameObject.FindGameObjectWithTag("MovePoint4");

        AllPoint[0] = point_0.transform;
        AllPoint[1] = point_1.transform;
        AllPoint[2] = point_2.transform;
        AllPoint[3] = point_3.transform;

    }
	
	// Update is called once per frame
	void Update () {
        TargetPoint = AllPoint[i].transform.position;

        transform.Translate(Vector3.Normalize(TargetPoint - transform.position) * Time.deltaTime * Speed);

        float Distance = Vector3.Distance(TargetPoint, transform.position);
        if (Distance < 0.5f)
        {
            if (i < AllPoint.Length - 1)
            {
                i++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
	}
}
