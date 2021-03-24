using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpointMoment : MonoBehaviour
{
    [SerializeField] float frequansy;
    [SerializeField] float hight;
    [SerializeField] float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationPath();
    }
    void rotationPath() {
        time = Mathf.Sin(Time.time);
        transform.RotateAroundLocal(Vector3.up, 1 / frequansy);
        transform.position = new Vector3 (transform.position.x,Mathf.Sin(Time.time) * hight, transform.position.z);
    }
}
