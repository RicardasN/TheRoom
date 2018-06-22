using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    public GameObject floor;

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
        if (PlayerPrefs.GetInt("FurnitureSelected") != -1)
        {
            var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
            float dist = Vector3.Distance(floor.transform.position, finalPosition);
            Debug.Log("Distance");
            Debug.Log(dist.ToString());
            Debug.Log(finalPosition);
            if (PlayerPrefs.GetInt("FurnitureSelected") == 0)
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.localScale = new Vector3((float)0.25, (float)1.5, 1);

                temp.transform.position = finalPosition;
                var tmp = temp.AddComponent(typeof(MouseDrag)) as MouseDrag;
                //padejom ir uzblokuojam vel dejima
                PlayerPrefs.SetInt("FurnitureSelected", -1);
                PlayerPrefs.Save();
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 1)
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.localScale = new Vector3((float)2.5, (float)1, 1);
                temp.transform.position = finalPosition;

                var tmp = temp.AddComponent(typeof(MouseDrag)) as MouseDrag;
                PlayerPrefs.SetInt("FurnitureSelected", -1);
                PlayerPrefs.Save();
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 2)
            {
                Debug.Log("Stalas");
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);

                Debug.Log(temp.transform.localScale);
                temp.transform.localScale = new Vector3((float)0.5, (float)0.5,(float) 0.5);
                //finalPosition.y += 1;
                //finalPosition.x -= 1 * (float)0.7;
                temp.transform.position = finalPosition;
                Debug.Log(temp.transform.position);

                var tmp = temp.AddComponent(typeof(MouseDrag)) as MouseDrag;
                PlayerPrefs.SetInt("FurnitureSelected", -1);
                PlayerPrefs.Save();
            }
            if (PlayerPrefs.GetInt("FurnitureSelected") == 3)
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.localScale = new Vector3((float)2, (float)0.9, (float)0.1);
                temp.transform.position = finalPosition;
                var tmp = temp.AddComponent(typeof(MouseDrag)) as MouseDrag;

                PlayerPrefs.SetInt("FurnitureSelected", -1);
                PlayerPrefs.Save();
            }
            /*else
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.position = finalPosition;
            }*/
            //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = nearPoint;
        }
    }
}