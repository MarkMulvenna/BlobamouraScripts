using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    [SerializeField] Rigidbody cameraTarget;
    Transform cameraTargetTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTargetTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraTargetTransform.position = cameraTarget.position;

    }
}
