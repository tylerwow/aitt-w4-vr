using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TeleporterScript : MonoBehaviour
{
    public Transform player;

    public Transform leftHand;

    public Material myMaterial;

    private LineRenderer myLine;

    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();

        // Set the material
        myLine.material = myMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input.GetStateDown("offroadteleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Fire out the teleport line");



            // Set the color
            myLine.startColor = Color.red;
            myLine.endColor = Color.green;

            // Set the width
            myLine.startWidth = 0.2f;
            myLine.endWidth = 0.2f;

            // Set the number of vertices
            myLine.positionCount = 3;    
        }

        if (SteamVR_Input.GetStateUp("offroadteleport", SteamVR_Input_Sources.LeftHand))
        {
            print("Teleport to the intersection point");
            Ray raycast = new Ray(leftHand.position, leftHand.forward);
            RaycastHit hit;

            myLine.SetPosition(0, transform.position);
            bool bHit = Physics.Raycast(raycast, out hit);
            myLine.SetPosition(1, hit.point);
            print(bHit);
            if (bHit)
            {
                Debug.Log(hit.point);
                player.position = hit.point;
                // Set the positions of the vertices

            }
            else
            {
                Debug.Log("no");
            }
        }
    }
}
