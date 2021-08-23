using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform cameraStart;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraStart.position;
        transform.rotation = cameraStart.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
