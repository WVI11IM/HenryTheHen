using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BatFollow : MonoBehaviour 
{
	public Transform target;
	GameObject chicken;

	public float batSpeed;
	public float minDistance;

    void Start()
    {
        
    }

    void Update () 
	{
		chicken = GameObject.FindWithTag("Player");
		target.position = chicken.transform.position;
		if (Vector2.Distance(transform.position, target.position) > minDistance)
        {
			transform.position = Vector2.MoveTowards(transform.position, target.position, batSpeed * Time.deltaTime);
        }
	}
}
