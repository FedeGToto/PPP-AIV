using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speedRot = 5f;
    public bool _360;
    bool back;

    float rot;

    void Update()
    {
        if (!_360)
        {
            if (!back)
            {
                rot += speedRot * Time.deltaTime;
                if (rot >= 80) back = true;
            }

            if (back)
            {
                rot -= speedRot * Time.deltaTime;
                if (rot <= -80) back = false;
            }
        }
        else
        {
            rot += speedRot * Time.deltaTime;
        }

        transform.localEulerAngles = new Vector3(0, 0, rot);
    }
}
