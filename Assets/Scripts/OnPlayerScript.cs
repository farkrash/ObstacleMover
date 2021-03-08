using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerScript : MonoBehaviour
{
    private Collider collider;
    private float yBounds;
    // Start is called before the first frame update
    void Start()
    {
        yBounds = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
