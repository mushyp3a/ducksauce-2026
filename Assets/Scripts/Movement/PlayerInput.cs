using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    HandMovementHandler handManager;
    public Transform[] positions;
    public float hangRadius;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handManager = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandMovementHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceJoint2D joint = null;
        if (Input.GetKeyDown(KeyCode.A))
        {
            int pos = 0;
            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            handManager.moveHand(true, positions[pos]);

            joint = gameObject.AddComponent<DistanceJoint2D>();

            joint.autoConfigureDistance = false;
            joint.autoConfigureConnectedAnchor = false;

            Rigidbody2D holdRb = positions[pos].GetComponent<Rigidbody2D>();

            joint.connectedBody = positions[pos].GetComponent<Rigidbody2D>();
            joint.distance = hangRadius;

            joint.enableCollision = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            int pos = 1;
            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            handManager.moveHand(true, positions[pos]);

            joint = gameObject.AddComponent<DistanceJoint2D>();

            joint.autoConfigureDistance = false;
            joint.autoConfigureConnectedAnchor = false;

            Rigidbody2D holdRb = positions[pos].GetComponent<Rigidbody2D>();

            joint.connectedBody = positions[pos].GetComponent<Rigidbody2D>();
            joint.distance = hangRadius;

            joint.enableCollision = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            int pos = 2;
            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            handManager.moveHand(false, positions[pos]);

            joint = gameObject.AddComponent<DistanceJoint2D>();

            joint.autoConfigureDistance = false;
            joint.autoConfigureConnectedAnchor = false;

            Rigidbody2D holdRb = positions[pos].GetComponent<Rigidbody2D>();

            joint.connectedBody = positions[pos].GetComponent<Rigidbody2D>();
            joint.distance = hangRadius;

            joint.enableCollision = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            int pos = 3;
            Destroy(gameObject.GetComponent<DistanceJoint2D>());
            handManager.moveHand(false, positions[pos]);

            joint = gameObject.AddComponent<DistanceJoint2D>();

            joint.autoConfigureDistance = false;
            joint.autoConfigureConnectedAnchor = false;

            Rigidbody2D holdRb = positions[pos].GetComponent<Rigidbody2D>();

            joint.connectedBody = positions[pos].GetComponent<Rigidbody2D>();
            joint.distance = hangRadius;

            joint.enableCollision = false;
        }
    }
}
