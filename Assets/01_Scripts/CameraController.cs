using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    private float camerasize;
    private float screenheight;
    void Start()
    {
        camerasize = Camera.main.orthographicSize;
        screenheight = camerasize * 2;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCameraPosition();
        //movCamare();
    }
    void movCamare()
    {
        camerasize = Camera.main.orthographicSize;
        screenheight = camerasize * 2;
    }
    void CalculateCameraPosition() 
    {
        int screencharacter = (int)(Player.position.x / screenheight);
        float Cameraheight = (screencharacter * screenheight) + camerasize;

        transform.position = new Vector3(Cameraheight, transform.position.y, transform.position.z);
    }

}
