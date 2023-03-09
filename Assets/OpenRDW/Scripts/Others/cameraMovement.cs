using System.Data;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Reflection;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cameraMovement : MonoBehaviour
{
    //[SerializeField]
    //public Transform device;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = 5.0f;
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(transform.GetComponentInChildren<Camera>().transform.forward * vertical * speed * Time.deltaTime);
        transform.Translate(transform.right * horizontal * speed * Time.deltaTime);

        /*UnityEngine.XR.InputDevice handR = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rot);
        handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.devicePosition, out Vector3 pos);
        Vector3 look = device.eulerAngles; //device.TransformDirection(Vector3.forward);*/
    }
}
