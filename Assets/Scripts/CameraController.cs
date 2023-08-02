using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Reset Camera Settings")]
    public float SixteenNinePos;
    public float SixteenTenPos;
    public float StartOrtho;

    [Header("Camera Control Settings")]
    public float scrollSpeed = 1f;
    public float moveSpeed = 1f;

    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();

        ResetCamera();
    }

    public void ResetCamera()
    {
        float aspect = (float)Screen.width / (float)Screen.height;
        print(aspect);

        if(aspect > 1.65)
        {
            transform.position = new Vector3(SixteenNinePos, 0f, -10f);
        }
        else if(aspect < 1.65)
        {
            transform.position = new Vector3(SixteenTenPos, 0f, -10f);
        }

        cam.orthographicSize = StartOrtho;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollDelta = Input.mouseScrollDelta.y * scrollSpeed * Time.deltaTime;

        if(scrollDelta != 0f)
        {

            if(cam.orthographicSize + scrollDelta < 1f)
            {
                cam.orthographicSize = 1f;
            }
            else
            {
                cam.orthographicSize += scrollDelta;
            }
        }

        if (Input.GetMouseButton(2))
        {
            float h = moveSpeed * Input.GetAxis("Mouse X");
            float v = moveSpeed * Input.GetAxis("Mouse Y");

            cam.transform.position += new Vector3(h, v, 0);
        }
    }
}
