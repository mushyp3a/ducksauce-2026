using UnityEngine;

public class TestHandManager : MonoBehaviour
{
    GameObject handManager;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handManager = GameObject.FindGameObjectWithTag("HandManager");
        // handManager.GetComponent<HandMovementHandler>().moveHand(true, target, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
