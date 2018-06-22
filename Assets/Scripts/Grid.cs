using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject GridObj;
    public Plane floor;
    [SerializeField]
    private float size = 0.1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        float x1 = GridObj.transform.position.x - PlayerPrefs.GetFloat("width") / 2;
        float z1 = GridObj.transform.position.z - PlayerPrefs.GetFloat("length") / 2;
        Gizmos.color = Color.yellow;
        for (float x = 0; x < PlayerPrefs.GetFloat("width"); x += size)
        {
            for (float z = 0; z < PlayerPrefs.GetFloat("length"); z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x1+x, GridObj.transform.position.y,z1+ z));
                Gizmos.DrawSphere(point, 0.1f);
            }
                
        }
    }
}