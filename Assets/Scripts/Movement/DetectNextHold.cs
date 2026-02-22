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

    public Transform rDefault;
    public Transform lDefault;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        handler = GameObject.FindGameObjectWithTag("HandManager").GetComponent<HandMovementHandler>();
    }

    public Transform leftChoose;

    // Update is called once per frame
    void Update()
    {
        nearPoints = new GameObject[0];
        nearCols = Physics2D.OverlapCircleAll(transform.position, 5f);
        nearPoints = nearCols.Select(col => col.gameObject).ToArray();
        nearPoints = nearPoints.Where(a => a.tag.Equals("HandHold")).ToArray();

        nearLeft = nearPoints.Where(a => a.transform.position.x < 0).ToArray();
        nearRight = nearPoints.Where(a => a.transform.position.x >= 0).ToArray();

        GameObject[] leftRankings = nearLeft.OrderByDescending(a => a.transform.position.y).ToArray();
        GameObject[] rightRankings = nearRight.OrderByDescending(a => a.transform.position.y).ToArray();

        foreach (var item in leftRankings)
        {
            Debug.Log(item.transform.position);
        }
        

        if (handler.rDefault)
        {
            if (rightRankings.Length > 0)
            {
            handler.moveHand(false, rightRankings.Last().transform, true);
                
            } else
            {
                handler.moveHand(false, rDefault, true);
            }
        }

        if (handler.lDefault)
        {
            
            if (leftRankings.Length > 0)
            {
                leftChoose = leftRankings.Last().transform;
                handler.moveHand(true, leftRankings.Last().transform, true);
            } else
            {
                handler.moveHand(true, lDefault, true);
            }
        } 
    }
}
