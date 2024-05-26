using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld Instance;
    [SerializeField] private LayerMask layerMask;
    private Camera camera;

    private void Awake()
    {
        Instance = this;
        camera = Camera.main;
    }
    // private void Update()
    // {
    //     if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, float.MaxValue, layerMask))
    //     {
    //         transform.position = hit.point;
    //     }
    // }
    public static Vector3 GetPosition()
    {
        Physics.Raycast(Instance.camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, float.MaxValue, Instance.layerMask);
        return hit.point;
    }
}
