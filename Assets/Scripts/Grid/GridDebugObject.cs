using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro tmp;
    public GridObject gridObject;

    public void SetGridObject(GridObject _gridObject)
    {
        this.gridObject = _gridObject;
        tmp.text = gridObject.ToString();
    }

    private void Update()
    {
        if (gridObject != null)
            tmp.text = gridObject.ToString();
    }
}
