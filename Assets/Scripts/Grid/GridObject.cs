using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> units;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        units = new List<Unit>();
    }

    public override string ToString()
    {
        string gridObjectString = "";
        foreach (Unit unit in units)
        {
            gridObjectString += unit + ",\n ";
        }
        return gridPosition.ToString() + ",\n " + gridObjectString;
    }
    public void AddUnit(Unit _unit)
    {
        units.Add(_unit);
    }
    public void RemoveUnit(Unit _unit)
    {
        if (units.Contains(_unit))
            units.Remove(_unit);
    }
    public List<Unit> GetUnitsList()
    {
        return units;
    }
    public bool HasAnyUnit()
    {
        return units.Count > 0;
    }
}
