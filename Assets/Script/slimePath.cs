using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimePath : MonoBehaviour
{
    public Transform[] points;
    public int speed;
    private int pointsIndex;
    private float dist;

    public void Start()
    {
        pointsIndex = 0;
        transform.LookAt(points[pointsIndex].position);
    }

    public void Update()
    {
        dist = Vector3.Distance(transform.position, points[pointsIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }


    public void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    public void IncreaseIndex()
    {
        pointsIndex++;
        if (pointsIndex >= points.Length)
        {
            pointsIndex = 0;
        }
        transform.LookAt(points[pointsIndex].position);
    }
}
