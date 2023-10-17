using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackCamera : MonoBehaviour
{

    private WebCamTexture webcamTexture;
    public Quaternion baseRotation;
    // Start is called before the first frame update
    void Start()
    {
        var renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture(1024, 1820);
        renderer.texture = webcamTexture;
        baseRotation = transform.rotation;
        webcamTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
       // webcamTexture.Play();
        transform.rotation = baseRotation * Quaternion.AngleAxis(webcamTexture.videoRotationAngle, Vector3.up);
    }
}
