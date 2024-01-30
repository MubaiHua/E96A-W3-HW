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
        elapsedTime = 0;
        transform.position = origin;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= updateTime)
        {
            MoveToRandomPosition();
            elapsedTime = 0;
        }

        transform.position = Vector3.Lerp(transform.position, origin, Time.deltaTime / updateTime);
    }

    void MoveToRandomPosition()
    {
        origin = new Vector3(
            Random.Range(-8f, 8f),
            transform.position.y,
            Random.Range(-8f, 8f)
        );
    }
}
