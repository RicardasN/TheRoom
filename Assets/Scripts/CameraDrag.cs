using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour
{

    float mainSpeed = 5.0f; //įprastinis greitis
    float camSens = 0.15f;
    public GameObject floor;
    private Vector3 lastMouse = new Vector3(255, 255, 255); 
    private float totalRun = 1.0f;
    private bool mouseRotate = false;

    void Start() {
        //Žiūrim, kad kamera atsirastų kambaryje
        float x = PlayerPrefs.GetFloat("width")/2;
        float y = -PlayerPrefs.GetFloat("height") + 2;
        float z = PlayerPrefs.GetFloat("length")/2;

        Vector3 newPosition = new Vector3(x, y, z);
        //Vector3 newPosition = new Vector3(floor.transform.position.x, floor.transform.position.y+1, floor.transform.position.z);
        //Debug.Log(newPosition);
        transform.position = newPosition;
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.C)&& mouseRotate==false)
            mouseRotate = true;
        else
            mouseRotate = false;
        
        if (mouseRotate)
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition; 
        }
        
        Vector3 p = GetBaseInput();

            totalRun = Mathf.Clamp(totalRun * 0.5f, (float)-2.5, (float)2.5);
            p = p * mainSpeed;

        p = p * Time.deltaTime;

        Vector3 newPosition = transform.position;
            transform.Translate(p);

    }

    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}