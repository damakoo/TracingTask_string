using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D))
        {
            this.transform.position = this.transform.position + new Vector3 (0.145f,0,0);
        }
        if(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
        {
            this.transform.position = this.transform.position + new Vector3 (-0.145f,0,0);
        }
        if(Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W))
        {
            this.transform.position = this.transform.position + new Vector3 (0,0.145f,0);
        }
        if(Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S))
        {
            this.transform.position = this.transform.position + new Vector3 (0,-0.145f,0);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }
}
