using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xclamping : MonoBehaviour
{
    private void Update()
    {
        //transform.eulerAngles = Vector3(0, ClampAngle(angle, ang0 - 40, ang0 + 40), 0);
        transform.eulerAngles = new Vector3(ClampAngle(transform.eulerAngles.x, -20, 20) ,0 , 0 );
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < 90 || angle > 270)
        {       // if angle in the critic region...
            if (angle > 180) angle -= 360;  // convert all angles to -180..+180

            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }
        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0) angle += 360;  // if angle negative, convert to 0..360
        return angle;
    }

}
