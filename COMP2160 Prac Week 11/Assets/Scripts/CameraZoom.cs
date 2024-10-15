using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{

    private Camera mainCam;

    #region FloatingNumbers
    private float changeRate = 0f;
    private float minZoom;
    private float maxZoom;
    private float zoomDivisor;
    private float sizeDivisor;
    #endregion

    #region Actions
    private Actions actions;
    private InputAction zoomAction;
    #endregion


void Awake()
{
    actions = new Actions();
   mainCam = Camera.main;
   zoomAction = actions.camera.zoom;
   minZoom = 50f;
   maxZoom = 80f;
   zoomDivisor = 100f;
   sizeDivisor =10f;

}

void OnEnable()
{
actions.camera.Enable();
}

void OnDisable()
{
actions.camera.Disable();
}


    // Update is called once per frame
    void Update()
    {

        changeRate = zoomAction.ReadValue<float>()/zoomDivisor;
        Debug.Log(zoomAction.ReadValue<float>());
        mainCam.fieldOfView-= changeRate;
        mainCam.fieldOfView = Mathf.Clamp(mainCam.fieldOfView, minZoom, maxZoom);

        mainCam.orthographicSize -= changeRate;
        mainCam.orthographicSize = Mathf.Clamp(mainCam.orthographicSize, minZoom/sizeDivisor, maxZoom/sizeDivisor);
    }


}
