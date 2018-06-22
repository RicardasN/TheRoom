using UnityEngine;
using System.Collections;

public class CameraDrag : MonoBehaviour
{

    float mainSpeed = 5.0f; //regular speed
    float camSens = 0.15f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
    private bool mouseRotate = false;

    void Start() {
        //Žiūrim, kad kamera atsirastų kambaryje
        float x = PlayerPrefs.GetFloat("width")/2;
        float y = -PlayerPrefs.GetFloat("height") + 2;
        float z = PlayerPrefs.GetFloat("length")/2;

        Vector3 newPosition = new Vector3(x,y,z);
        //Debug.Log(newPosition);
        transform.position = newPosition;
    }
    void Update()
    {
        //camera locks
        if (Input.GetKey(KeyCode.C)&& mouseRotate==false)
            mouseRotate = true;
        else
            mouseRotate = false;
        //Mouse camera angles
        if (mouseRotate)
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition; 
        }
        //Keyboard commands
        Vector3 p = GetBaseInput();

            totalRun = Mathf.Clamp(totalRun * 0.5f, (float)-2.5, (float)2.5);
            p = p * mainSpeed;

        p = p * Time.deltaTime;

        Vector3 newPosition = transform.position;
            transform.Translate(p);

    }

    private Vector3 GetBaseInput()
    { //returns the basic values, if it's 0 than it's not active.
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