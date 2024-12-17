using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GridPosition : IEquatable<GridPosition>
{
    public int x;
    public int z;

    public GridPosition(int x, int y)
    {
        this.x = x;
        this.z = y;
    }
    public override string ToString()
    {
        return $"x: {x}, z: {z}";
    }

    public bool Equals(GridPosition other)
    {
        return this == other;
    }
    public override bool Equals(object obj)
    {
        return obj is GridPosition position && position.x == x && position.z == z;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }
    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }
    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }
}
