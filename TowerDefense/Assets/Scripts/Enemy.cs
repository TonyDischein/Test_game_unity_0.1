using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private List<Transform> wayPoints;
	[SerializeField] private float speed = 2f;
	[SerializeField] private float switchingDistance = 2f;

	private Transform targetPoint;
	private Queue<Transform> wayPointsQueue;

	void Update () {
        Move();
    }

	private void Move()
	{
		if (targetPoint == null)
		{
			ChangeTargetPoint();
		}

		transform.Translate(Vector3.Normalize(targetPoint.position - transform.position) * Time.deltaTime * speed);
		if (Vector3.Distance(targetPoint.position, transform.position) <= switchingDistance)
		{
			if (wayPoints.Count > 0)
			{
				ChangeTargetPoint();
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}

	private void ChangeTargetPoint()
	{
		targetPoint = wayPoints.First();
		wayPoints.Remove(targetPoint);
	}
}
