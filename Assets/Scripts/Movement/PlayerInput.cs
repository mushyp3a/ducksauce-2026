using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HandMovementHandler handManager;
    public Transform[] positions;
    public float hangRadius;

    HoldDetector rHand;
    HoldDetector lHand;

    public Transform rDefault;
    public Transform lDefault;

    Rigidbody2D rb;
    bool holding;

    bool left;

    public float targetVelocity;
    public float forceStrength;

    public AudioClip grabClip;
    public AudioClip pullClip;
    public AudioClip releaseClip;

    private HoldDetector currentHand;

    void PlayGrap()
    {
        if (grabClip)
        {
            AudioSource.PlayClipAtPoint(grabClip, transform.position, 1);
        }
    }
    
    void PlayPull()
    {
        if (pullClip)
        {
            AudioSource.PlayClipAtPoint(pullClip, transform.position, 1);
        }
    }

    void PLayRelease()
    { 
        if (releaseClip)
        {
            AudioSource.PlayClipAtPoint(releaseClip, transform.position, 1);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        left = false;
        targetVelocity = 0;
        holding = false;
        handManager = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandMovementHandler>();
        rb = GetComponent<Rigidbody2D>();
        rHand = GameObject.FindGameObjectWithTag("rHand").GetComponent<HoldDetector>();
        lHand = GameObject.FindGameObjectWithTag("lHand").GetComponent<HoldDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceJoint2D joint = null;
        if (Input.GetKey(KeyCode.Space))
        {
            if (holding)
            {
                targetVelocity = Mathf.Min(targetVelocity + Time.deltaTime, 8);
                if (left)
                {
                    if (transform.position.y < lHand.pos.position.y && rb.linearVelocity.magnitude < targetVelocity)
                    {
                        rb.linearVelocity = rb.linearVelocity.normalized * targetVelocity;
                    }
                    else if (transform.position.y >= lHand.pos.position.y && rb.linearVelocityY > 0)
                    {
                        rb.linearVelocity *= 0.97f;
                    }
                    else
                    {
                        rb.gravityScale = 1;
                    }
                }
                else
                {
                    if (transform.position.y < rHand.pos.position.y && rb.linearVelocity.magnitude < targetVelocity)
                    {
                        rb.linearVelocity = rb.linearVelocity.normalized * targetVelocity;
                    }
                    else if (transform.position.y >= rHand.pos.position.y && rb.linearVelocityY > 0)
                    {
                        rb.linearVelocity *= 0.97f;
                    }
                    else
                    {
                        rb.gravityScale = 1;
                    }
                }
            }
            if (rHand.nearHold && !holding)
            {
                PlayGrap();

                left = false;
                targetVelocity = rb.linearVelocity.magnitude;
                handManager.moveHand(false, rHand.pos, false);
                handManager.moveHand(true, lDefault, true);
                Destroy(gameObject.GetComponent<DistanceJoint2D>());

                joint = gameObject.AddComponent<DistanceJoint2D>();

                joint.autoConfigureDistance = false;
                joint.autoConfigureConnectedAnchor = false;

                Rigidbody2D holdRb = rHand.pos.GetComponent<Rigidbody2D>();

                joint.connectedBody = holdRb;
                joint.distance = hangRadius;

                joint.enableCollision = false;
                holding = true;

                currentHand = rHand;
            }
            else if (lHand.nearHold && !holding)
            {
                PlayGrap();

                left = true;
                targetVelocity = rb.linearVelocity.magnitude;
                handManager.moveHand(true, lHand.pos, false);
                handManager.moveHand(false, rDefault, true);
                Destroy(gameObject.GetComponent<DistanceJoint2D>());

                joint = gameObject.AddComponent<DistanceJoint2D>();

                joint.autoConfigureDistance = false;
                joint.autoConfigureConnectedAnchor = false;

                Rigidbody2D holdRb = lHand.pos.GetComponent<Rigidbody2D>();

                joint.connectedBody = holdRb;
                joint.distance = hangRadius;

                joint.enableCollision = false;
                holding = true;

                currentHand = lHand;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && holding)
        {
            PLayRelease();

            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            holding = false;
            Debug.Log(currentHand.holdScript.getMult());
            rb.linearVelocity = rb.linearVelocity.normalized * rb.linearVelocity.magnitude * 1.5f * currentHand.holdScript.getMult();
            handManager.moveHand(true, lDefault, true);
            handManager.moveHand(false, rDefault, true);

            currentHand = null;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && (!rDefault || !lDefault))
        {
            PlayPull();

            rb.AddForceY(forceStrength, ForceMode2D.Impulse);
        }
    }
}
