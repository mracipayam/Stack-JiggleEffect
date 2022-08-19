using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeFollow : MonoBehaviour
{
    public Transform followingTarget;
    
    void Update()
    {
        transform.position =
            new Vector3(Mathf.Lerp(transform.position.x, followingTarget.position.x, 30 * Time.deltaTime),
                transform.position.y,
                Mathf.Lerp(transform.position.z, followingTarget.position.z, 30 * Time.deltaTime)
                );
    }
}
