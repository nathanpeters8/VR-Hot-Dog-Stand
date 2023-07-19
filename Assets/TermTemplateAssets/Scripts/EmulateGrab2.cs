﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//********************************************************************************************//
//*****DEACTIVATE THIS SCRIPT AND ACTIVATE GRAB2 BEFORE TAKING TEST BUILDS FOR OCULUS GO******//
//**REMOVE THIS SCRIPT FROM THE HAND GAME OBJECT BEFORE TAKING THE FINAL BUILD FOR OCULUS GO**//
//********************************************************************************************//

//Press W while the Game View is active, rotate the Oculus Go controller with the left mouse button
//Grab objects by hovering and clicking down the left mouse button
//Scroll up and down the mouse wheel to move the grabbed object (while grabbing) or the marker in z-axis
//Press the 'E' and the 'R' keys to instantiate prefabs at the marker's position

public class EmulateGrab2 : MonoBehaviour
{
    float controllerSpeedHorizontal = 1.5f;
    float controllerSpeedVertical = 1.5f;
    float controllerYaw = 0.0f;
    float controllerPitch = 0.0f;

    bool isGrabbing = false;
    bool isLooking = false;
    Transform grabbedTransform;
    float zSpeed = 3.8f;
    public float rotationSpeedMultiplier = 5.0f;
    private Transform hitTransform;
    public GameObject CubePrefabVar, SpherePrefabVar;

    void Start()
    {
        transform.localPosition = new Vector3(0.2f, -0.4f, 0.6f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            EmulateHeadRotation.isLimited = true;
            controllerYaw += controllerSpeedHorizontal * Input.GetAxis("Mouse X") * rotationSpeedMultiplier;
            controllerPitch += controllerSpeedVertical * Input.GetAxis("Mouse Y") * -rotationSpeedMultiplier;
            transform.localRotation = Quaternion.Euler(controllerPitch, controllerYaw, 0.0f);
        }

        if (Input.GetKeyUp(KeyCode.W))
            EmulateHeadRotation.isLimited = false;

        RaycastHit hitInfo2;
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out hitInfo2))
        {
            if (hitInfo2.transform.tag == "Grabbable")
            {
                if (hitTransform != null)
                    SetHighlight(hitTransform, false);

                hitTransform = hitInfo2.transform;
                SetHighlight(hitTransform, true);
                isLooking = true;
            }
            else
            {
                if (hitTransform != null && !isGrabbing)
                    SetHighlight(hitTransform, false);
                isLooking = false;
            }
        }
        else
        {
            if (hitTransform != null && !isGrabbing)
            {
                SetHighlight(hitTransform, false);
            }
            isLooking = false;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out hitInfo))
            {
                if (hitInfo.transform.tag == "Grabbable")
                {
                    isGrabbing = true;
                    grabbedTransform = hitInfo.transform;
                    grabbedTransform.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedTransform.GetComponent<Rigidbody>().useGravity = false;
                    grabbedTransform.parent = transform;
                }
            }
        }

        if (isGrabbing && Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (grabbedTransform != null)
            {
                grabbedTransform.GetComponent<Rigidbody>().isKinematic = false;
                grabbedTransform.GetComponent<Rigidbody>().useGravity = true;
                grabbedTransform.parent = null;
            }
            isGrabbing = false;
        }

        if (isGrabbing)
        {
            float distance = Input.mouseScrollDelta.y;

            grabbedTransform.position += distance * zSpeed * Time.deltaTime * transform.forward;
            grabbedTransform.localPosition = new Vector3(grabbedTransform.localPosition.x, grabbedTransform.localPosition.y, Mathf.Clamp(grabbedTransform.localPosition.z, 0.4f, 7.0f));

        }

        if (!isGrabbing)
        {
            float distance = Input.mouseScrollDelta.y;

            transform.GetChild(0).position += distance * Time.deltaTime * zSpeed * transform.forward;
            transform.GetChild(0).localPosition = new Vector3(transform.GetChild(0).localPosition.x, transform.GetChild(0).localPosition.y, Mathf.Clamp(transform.GetChild(0).localPosition.z, 0.4f, 7.0f));
        }

        if (!isLooking && !isGrabbing && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(CubePrefabVar, transform.GetChild(0).position, transform.GetChild(0).rotation);
        }

        if (!isLooking && !isGrabbing && Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(SpherePrefabVar, transform.GetChild(0).position, Quaternion.identity);
        }

    }

    void SetHighlight(Transform t, bool highlight)
    {
        if (highlight)
        {
            t.GetComponent<Renderer>().material.color = Color.cyan;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            t.GetComponent<Renderer>().material.color = t.GetComponent<IsHit_S>().originalColorVar;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
        }
    }
}
