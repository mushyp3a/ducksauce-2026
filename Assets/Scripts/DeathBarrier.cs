using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public int rate;

    public Collider2D collider;

    public Animator transition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
