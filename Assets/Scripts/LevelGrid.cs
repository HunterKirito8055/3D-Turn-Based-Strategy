using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;


        gridSystem = new GridSystem(10, 10, 2);

        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);

    }
    // public void SetUnitAtGridPosition(Unit _unit)
    // {
    //     GridObject gridObject = gridSystem.GetGridObject(GetGridPosition(_unit.transform.position));
    //     gridObject.SetUnit(_unit);
    // }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit _unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(_unit);
    }

    public Unit GetUnitAtGridPosition(GridPosition gridPosition)
    {
        return gridSystem.GetGridObject(gridPosition).GetUnit();
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(null);
    }
    public void UnitMovedGridPosition(Unit _unit, GridPosition _from, GridPosition _to)
    {
        ClearUnitAtGridPosition(_from);
        AddUnitAtGridPosition(_to, _unit);
    }
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
}
