using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    private Transform camtrans;
    private Transform playertrans;
    private Camera cam;
    public GameObject Player;
    float width;
    float height;
    Vector3 dir = new Vector3(0, 0, -10); 
    void Start()
    {
        camtrans = GetComponent<Transform>();
        playertrans = Player.GetComponent<Transform>();
        cam = GetComponent<Camera>();
        width = cam.orthographicSize  * cam.aspect;
        height = cam.orthographicSize ;
    }

    void Update()
    {
        if (playertrans.position.x - width > -2f && playertrans.position.x + width < 2f)
        {
            dir.x = playertrans.position.x;
        }
        if (playertrans.position.y - height > -2.45f && playertrans.position.x + height < 2.45f)
        {
            dir.y = playertrans.position.y;
        }
        camtrans.position = dir;
    }
}
