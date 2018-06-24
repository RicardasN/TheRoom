using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    float distance = 5;
    private Grid grid;
    bool objSelected=true;
    /*private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }*/
    public void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        gameObject.transform.position = objPosition;


        //objekto matmenys
        float x = gameObject.transform.localScale.x, y = gameObject.transform.localScale.y, z = gameObject.transform.localScale.z;
        if (transform.eulerAngles.y != 0)
            if ((gameObject.transform.eulerAngles.y > 85 && gameObject.transform.eulerAngles.y < 95) ||
                (gameObject.transform.eulerAngles.y > -95 && gameObject.transform.eulerAngles.y < -85))
            { float tmp = z; z = x; x = tmp; }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                gameObject.transform.position = ClosestWallOffset(hitInfo.point, x,
                    z, y);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y + 90,
                gameObject.transform.eulerAngles.z
            );
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
            gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y - 90,
                gameObject.transform.eulerAngles.z
            );
}
    void Update()
    {
            
    }
    private Vector3 ClosestWallOffset(Vector3 finalPosition, double w, double l, double h)
    {

        if (Camera.main.transform.position.z > finalPosition.z)
        {
            finalPosition.z += (float)(l*0.5);
        }

        if (Camera.main.transform.position.x > finalPosition.x)
        {
            finalPosition.x += (float)(w * 0.5);
        }
        if (Camera.main.transform.position.x < finalPosition.x)
        {
            finalPosition.x -= (float)(w * 0.5);
        }

        if (Camera.main.transform.position.z < finalPosition.z)
        {
            finalPosition.z -= (float)(l * 0.5);
        }
        //setting y higher so it does not go through the ground
        finalPosition.y += (float)(h * 0.5);

        return finalPosition;
    }
}
