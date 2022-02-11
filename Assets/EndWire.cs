using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWire : MonoBehaviour
{
    private Touch theTouch;
    private Vector2 touchStartPos;
    //private float distanceFromChainEnd = 0.5f;
    public GameObject wire;
    bool isWrong = false;
    public GameObject parent;

    public void ConnectWireEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint =  gameObject.GetComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = new Vector2(-5f, 0f);
        joint.connectedAnchor = new Vector2(0f, 0f);
    }
    private void OnMouseEnter()
    {
        isWrong = false;
    }

    private void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            touchStartPos = Camera.main.ScreenToWorldPoint(new Vector2(theTouch.position.x, theTouch.position.y));
            if (!isWrong)
            {
                gameObject.transform.position = touchStartPos;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            wire.SetActive(true);
            parent.SetActive(false);
        }
        else
        {
            isWrong = true;
        }
    }
}
