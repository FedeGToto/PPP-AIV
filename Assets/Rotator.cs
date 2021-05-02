using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speedRot = 5f;
    bool back;
    void Update()
    {
        transform.eulerAngles += Vector3.forward * speedRot * Time.deltaTime;
        if (transform.localEulerAngles.z >= 80 && !back)
        {
            speedRot = -Mathf.Abs(speedRot);
            back = true;
        }
        else if(back)
        {
            if (transform.localEulerAngles.z <= 280 && transform.localEulerAngles.z >= 265)
            {
                back = false;
                speedRot = Mathf.Abs(speedRot);
            }
        }
    }
}
