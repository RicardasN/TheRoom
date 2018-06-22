using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject floor;
    public MaterialOptions materialSelector;

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
            //Randame artimiausią poziciją ant grid prie kurios snapinsim (bug)
            var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
            float dist = Vector3.Distance(floor.transform.position, finalPosition);
            Debug.Log("Distance");
            Debug.Log(dist.ToString());

           //Surandam kuris pasirinktas ir tą įterpiame
            if (PlayerPrefs.GetInt("FurnitureSelected") == 0)
            {
                CreateFurniture(finalPosition, 0.25, 1.5, 1);
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 1)
            {
                CreateFurniture(finalPosition, 2.5, 1, 1);
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 2)
            {
                CreateFurniture(finalPosition, 0.5, 0.5, 0.5);
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 3)
            {
                CreateFurniture(finalPosition, 2, 0.9, 0.1);
            }
            /*else
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.position = finalPosition;
            }*/
            //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
        }
    }
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