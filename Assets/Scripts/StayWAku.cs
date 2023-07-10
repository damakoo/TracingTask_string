using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayWAku : MonoBehaviour
{
    private Vector3 thispos;
    private Quaternion thisrot;
    // Start is called before the first frame update
    void Start()
    {
        thispos = this.transform.position;
        thisrot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = thispos;
        this.transform.rotation = thisrot;
    }
}
