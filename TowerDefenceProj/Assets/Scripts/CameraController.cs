using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Attributes")]
    public float panspeed = 30f;     //Camera Moving Speed
    public float panBorderThickness = 10f;  //Distance away from top of the screen
    public float scrollSpeed = 2f;   //Scroll Speed
    public float minY = 10f;         //Minimum Y Value
    public float maxY = 80f;         //Maximum Y Value

    // Update is called once per frame
    void Update()
    {
        //Camera Freeze When Game is Over
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        //Toggle Key & Mouse Movement of Camera
        //Move Camera to the Top
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)   //When Key W or MousePosition is more or equal to current Top of the Screen Height, move camera upwards
        {
            transform.Translate(Vector3.forward * panspeed * Time.deltaTime, Space.World);
        }

        //Move Camera to the Bottom
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)                   //When Key S or MousePosition is more or equal to current Bottom of the Screen Height, move camera downwards
        {
            transform.Translate(Vector3.back * panspeed * Time.deltaTime, Space.World);
        }

         //Move Camera to the Left
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)                   //When Key A or MousePosition is more or equal to current Left side of the ScreenScreen Width, move camera to the left
        {
            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
        }

        //Move Camera to the Right
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)    //When Key D or MousePosition is more or equal to current Right side of the Screen Width, move camera to the right
        {
            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
        }

        //Scroll to Zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");  //Get the function Scroll Wheel
        Vector3 pos = transform.position;                   //Current Position
        pos.y -= scroll * 1000 * Time.deltaTime;            //Smoother Scroll
        pos.y = Mathf.Clamp(pos.y, minY, maxY);             //To lock the Y-Axis when Scrolling to prevent scrolling past the Ground
        transform.position = pos;                           //Apply Updated Position
    }
}
