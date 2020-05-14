using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digits : MonoBehaviour
{
    [SerializeField] float radius = 0.45f;
    [SerializeField] Transform centerPoint;

    void Start()
    {
        int childCount = transform.childCount;
        float angle = 360f / childCount;
        int childNumber = 0;

        foreach (Transform child in transform)
        {
            child.localPosition = new Vector3(centerPoint.position.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad * childNumber),
                centerPoint.position.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad * childNumber));
            childNumber++;
        }
    }
}
