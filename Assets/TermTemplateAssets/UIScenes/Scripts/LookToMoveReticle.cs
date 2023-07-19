using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToMoveReticle : MonoBehaviour
{
    public GameObject ground;
    public GameObject startBoard;
    private bool startBoardActive;

    void Start()
    {
        startBoardActive = true; //We make the starting board active at start
    }

    void Update()
    {
        if (startBoardActive == true)
        {
            if (Input.GetKeyDown(KeyCode.J)) //This should be changed to if (Input.anyKey) for Oculus Go build
            {
                startBoard.SetActive(false);
                startBoardActive = false;
            }
        }

        if (startBoardActive == false) //We are not letting the user play unless the starting board is deactivated
        {
            Transform camera = Camera.main.transform;

            Ray ray;
            RaycastHit hit;
            GameObject hitObject;

            ray = new Ray(camera.position, camera.rotation * Vector3.forward);
            if (Physics.Raycast(ray, out hit))
            {
                hitObject = hit.collider.gameObject;

                if (hitObject == ground)
                {
                    transform.position = hit.point;
                }
            }
        }
    }

}