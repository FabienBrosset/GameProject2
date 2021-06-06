using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningControllerDefense : MonoBehaviour
{
    private float lifeTime = 0.5f;

    private float creationTime = 0f;

    private void Start()
    {
        creationTime = Time.time;
    }

    void Update()
    {
        if (Time.time - creationTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
