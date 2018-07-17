using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
#if UNITY_EDITOR
    float sensitivity1 = 700.0f;
    float rotationX;
    float rotationY;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rotationX = -transform.eulerAngles.x;
            rotationY = transform.eulerAngles.y;
        }

        if (Input.GetKey(KeyCode.LeftAlt) == false)
            return;

        float mouseMoveValueX = Input.GetAxis("Mouse X");
        float mouseMoveValueY = Input.GetAxis("Mouse Y");

        rotationY += mouseMoveValueX * sensitivity1 * Time.deltaTime;
        rotationX += mouseMoveValueY * sensitivity1 * Time.deltaTime;

        rotationX %= 360;
        rotationY %= 360;

        rotationX =  Mathf.Clamp(rotationX, -90.0f, 90.0f);

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
    }
#endif
}
