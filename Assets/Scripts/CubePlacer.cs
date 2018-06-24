using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject floor;
    public MaterialOptions materialSelector;
    public Plane wall1, wall2, wall3, wall4;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                PlaceCubeNear(hitInfo.point);
            }
        }
    }
   
    private void PlaceCubeNear(Vector3 clickPoint)
    {
        //Jei yra pasirinktų baldų dėti
        if (PlayerPrefs.GetInt("FurnitureSelected") != -1)
        {

           //Surandam kuris pasirinktas ir tą įterpiame
            if (PlayerPrefs.GetInt("FurnitureSelected") == 0)
            {
               
                CreateFurniture(ClosestWallOffset(clickPoint, 0.25, 1.5, 1), 0.25, 1.5, 1);
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 1)
            {
                CreateFurniture(ClosestWallOffset(clickPoint, 2.5, 1, 1), 2.5, 1, 1);
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 2)
            {
                CreateFurniture(ClosestWallOffset(clickPoint, 0.5, 0.5, 0.5), 0.5, 0.5, 0.5);
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 3)
            {
                CreateFurniture(ClosestWallOffset(clickPoint, 2, 0.9, 0.1), 2, 0.9, 0.1);
            }
            /*else
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.position = finalPosition;
            }*/
            //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
        }
    }
    private Vector3 ClosestWallOffset(Vector3 finalPosition, double w, double l, double h)
    {

        if (Camera.main.transform.position.z > finalPosition.z)
        {
            finalPosition.z += (float)(l * 0.5);
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
    /// <summary>
    /// Creates a furniture object given it's size parameters on a nearest plane
    /// </summary>
    /// <param name="finalPosition"></param>
    /// <param name="w"></param>x
    /// <param name="l"></param>z
    /// <param name="h"></param>y
    private void CreateFurniture(Vector3 finalPosition, double w, double l, double h)
    {
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        temp.transform.localScale = new Vector3((float)w, (float)l, (float)0.1);

        temp.transform.position = finalPosition;
        MeshRenderer m = temp.GetComponent<MeshRenderer>();
        Material[] materials = m.materials;
        temp.GetComponent<MeshRenderer>().material = materials[PlayerPrefs.GetInt("material")];

        var tmp = temp.AddComponent(typeof(MouseDrag)) as MouseDrag;

        PlayerPrefs.SetInt("FurnitureSelected", -1);
        PlayerPrefs.Save();
    }
}