using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallJump : MonoBehaviour
{
    private Vector3 origin;
    private float elapsedTime;
    [SerializeField] private float updateTime = 1f;

    void Start()
    {
        origin = new Vector3(-2 + Random.Range(-3f, 3f), 1.5f, Random.Range(-3f, 3f));
        transform.position = origin;
    }

    void Update()
    {
    }
}
