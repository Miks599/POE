using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour   //https://answers.unity.com/questions/827105/smooth-2d-camera-zoom.html
{

    public float fZoomSpeed = 1;
    public float fTargetOrtho;
    public float fSmoothSpeed = 2.0f;
    public float fMinOrtho = 1.0f;
    public float fMaxOrtho = 20.0f;

    void Start()
    {
        fTargetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            fTargetOrtho -= scroll * fZoomSpeed;
            fTargetOrtho = Mathf.Clamp(fTargetOrtho, fMinOrtho, fMaxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, fTargetOrtho, fSmoothSpeed * Time.deltaTime);
    }
}
