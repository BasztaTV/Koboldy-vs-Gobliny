using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public void OnMouseDown()
    {
        CameraController.instance.followTranform = transform;
    }
}
