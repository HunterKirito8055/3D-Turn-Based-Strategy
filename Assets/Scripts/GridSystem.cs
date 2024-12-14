using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int width, height;

    public GridSystem(int width, int height)
    {
        this.width = width;
        this.height = height;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var worldPos = GetWorldPosition(x, y);
                Debug.DrawLine(worldPos, worldPos + Vector3.right * 0.25f, Color.white, 1000f);
            }
        }
    }
    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z);
    }
}
