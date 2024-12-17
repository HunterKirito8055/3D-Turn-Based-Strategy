using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed, rotateSpeed;
    [SerializeField] private Animator animator;
    private Vector3 targetPosition;
    private float stoppingDistance = 0.1f;

    [SerializeField] private GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Start()
    {
        // LevelGrid.Instance.SetUnitAtGridPosition(this);
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }
    private void Update()
    {
        Moving();
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
        //
        // if (Input.GetMouseButtonDown(0))
        // {
        //     targetPosition = MouseWorld.GetPosition();
        // }
    }
    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
    }
    private void Moving()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDir = (targetPosition - transform.position).normalized;
            transform.position += moveDir * Time.deltaTime * moveSpeed;

            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
