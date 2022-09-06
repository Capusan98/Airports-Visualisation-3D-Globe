using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float autoSpinSpeed = 1f;
    private bool spin = false;

    private void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;    
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        Vector3 dir = new Vector3(-1, 0, -1);

        transform.Rotate(Vector3.up, XaxisRotation);
        transform.Rotate(dir, YaxisRotation);
    }

    private void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            scroll = -scroll;
            scroll = scroll / 10;
            transform.localScale = new Vector3(transform.localScale.x+scroll, transform.localScale.y + scroll, transform.localScale.z + scroll);
        }

        if (spin)
        {
            transform.Rotate(Vector3.up, autoSpinSpeed);
        }

    }

    public void SetSpin()
    {
        spin = !spin;
    }
}

