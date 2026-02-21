using UnityEngine;
using System.Linq;

public class DetectNextHold : MonoBehaviour
{
    GameObject[] nearPoints;
    Collider2D[] nearCols;

    GameObject[] nearRight;
    GameObject[] nearLeft;

    public LayerMask handHold;

    HandMovementHandler handler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handler = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandMovementHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        nearPoints = new GameObject[0];
        nearCols = Physics2D.OverlapCircleAll(transform.position, 2f);
        nearPoints = nearCols.Select(col => col.gameObject).ToArray();
        nearPoints = nearPoints.Where(a => a.tag.Equals("HandHold")).ToArray();

        nearLeft = nearPoints.Where(a => a.transform.position.x < 0).ToArray();
        nearRight = nearPoints.Where(a => a.transform.position.x >= 0).ToArray();

        GameObject leftHighest = nearLeft.OrderByDescending(a => a.transform.position.y).Last();
        GameObject rightHighest = nearRight.OrderByDescending(a => a.transform.position.y).Last();
        GameObject max = leftHighest;
        if (rightHighest.transform.position.y >= leftHighest.transform.position.y)
        {
            max = rightHighest;
        }

        if (handler.rDefault)
        {
            handler.moveHand(false, rightHighest.transform, true);
        }
        if (handler.lDefault)
        {
            handler.moveHand(true, leftHighest.transform, true);
        }
    }
}
