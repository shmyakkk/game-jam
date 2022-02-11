using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    private int links = 10;

    public EndWire endWire;
    private void Start()
    {
        GenerateRope();
    }
    private void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        
        for (int i = 0; i < links; i++)
        {
            GameObject link =  Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.autoConfigureConnectedAnchor = false;
            //joint.connectedAnchor = new Vector2(0f, -0.1f);
            joint.connectedBody = previousRB;

            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                endWire.ConnectWireEnd(link.GetComponent<Rigidbody2D>());
            }
            
        }
    }
}
