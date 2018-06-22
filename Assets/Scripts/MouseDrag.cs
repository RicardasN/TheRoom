using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    float distance = 5;
    private Grid grid;
    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }
    public void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            var finalPosition = grid.GetNearestPointOnGrid(objPosition);
            transform.position = finalPosition;
        }

    }
    //Metodas snapinti padraginus objektą
   /* Vector3 SnapToGrid(Vector3 Position)
    {
        GameObject grid = GameObject.Find("grid");
        if (!grid)
            return Position;

        //    get grid size from the texture tiling
        Vector2 GridSize = grid.renderer.material.mainTextureScale;

        //    get position on the quad from -0.5...0.5 (regardless of scale)
        Vector3 gridPosition = grid.transform.InverseTransformPoint(Position);
        //    scale up to a number on the grid, round the number to a whole number, then put back to local size
        gridPosition.x = Mathf.Round(gridPosition.x * GridSize.x) / GridSize.x;
        gridPosition.y = Mathf.Round(gridPosition.y * GridSize.y) / GridSize.y;

        //    don't go out of bounds
        gridPosition.x = Mathf.Min(0.5f, Mathf.Max(-0.5f, gridPosition.x));
        gridPosition.y = Mathf.Min(0.5f, Mathf.Max(-0.5f, gridPosition.y));

        Position = grid.transform.TransformPoint(gridPosition);
        return Position;
    }*/
}
