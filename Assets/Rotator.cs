using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speedRot = 5f;
    void Update()
    {
        transform.eulerAngles += Vector3.forward * speedRot * Time.deltaTime;
        if (transform.localEulerAngles.z >= 80)
        {
            speedRot = -Mathf.Abs(speedRot);
        }
        else if(transform.localEulerAngles.z <= -80)
        {
            speedRot = Mathf.Abs(speedRot);
        }
    }
}
