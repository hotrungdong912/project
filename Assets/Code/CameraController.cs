using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{



    public float panSpeed = 30f;


    public float minY = 10f;
    public float maxY =4f;



    public float panBorderThickness = 10f;
    public float scrollspeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = true;
        }
      
        Vector3 pos = transform.position;

        if(Input.GetKey("w") )
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") )
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") )
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") )
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * 500 * scrollspeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x,-62,-10);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, 10, 88);
        transform.position = pos;
    }
}
