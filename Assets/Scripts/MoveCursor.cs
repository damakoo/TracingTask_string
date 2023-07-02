using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    [SerializeField] bool isleft;
    Rigidbody2D thisrigidbody;
    // Start is called before the first frame update
    void Start()
    {
        thisrigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isleft)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //this.transform.position = this.transform.position + new Vector3(0, 0.05f, 0);
                thisrigidbody.AddForce(new Vector3(0, 30000000f, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                //this.transform.position = this.transform.position + new Vector3(0, -0.05f, 0);
                thisrigidbody.AddForce(new Vector3(0, -30000000f, 0));
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //this.transform.position = this.transform.position + new Vector3(0, 0.05f, 0);
                thisrigidbody.AddForce(new Vector3(0, 30000000f, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //this.transform.position = this.transform.position + new Vector3(0, -0.05f, 0);
                thisrigidbody.AddForce(new Vector3(0, -30000000f, 0));
            }

        }
    }
}
