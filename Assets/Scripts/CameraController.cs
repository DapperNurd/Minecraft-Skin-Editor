using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera drawingCam;
    public Camera modelCam;

    [SerializeField] GameObject model;

    private void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drawingCam.pixelRect.Contains(Input.mousePosition)) {
            // Mouse over drawing camera

            
        }
        else if (modelCam.pixelRect.Contains(Input.mousePosition)) {
            // Mouse over model camera
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && modelCam.fieldOfView > 10f) {
                modelCam.fieldOfView -= modelCam.fieldOfView/20f;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && modelCam.fieldOfView < 100f) {
                modelCam.fieldOfView += modelCam.fieldOfView/20f;
            }
            if (Input.GetMouseButton(0)) {
                model.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 5, -Input.GetAxis("Mouse X") * 5, 0));
            }
        }
    }
}
