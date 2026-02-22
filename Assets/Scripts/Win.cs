using UnityEngine;

public class Win : MonoBehaviour
{
    public ClimbCameraController cam;
    public GameTimer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            timer.StopTimer();
            GameObject.FindGameObjectWithTag("Player").GetComponent<explode>().explodeGuy();
        }
    }
}
