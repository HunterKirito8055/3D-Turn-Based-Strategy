using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector3 targetPosition;
    private float stoppingDistance = 0.1f;

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDir = (targetPosition - transform.position).normalized;

            transform.position += moveDir * Time.deltaTime * moveSpeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
    }

    public void Move(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }
}
