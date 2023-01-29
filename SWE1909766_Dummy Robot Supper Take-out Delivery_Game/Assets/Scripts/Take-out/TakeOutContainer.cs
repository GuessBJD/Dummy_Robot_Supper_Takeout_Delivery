using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOutContainer : MonoBehaviour
{
    [SerializeField] private BagManager bagManager;
    [SerializeField] private OrderManager orderManager;

    // Start is called before the first frame update
    void Awake()
    {

    }

    public void resetTakeOut()
    {
        bagManager.dropAll();
    }

    public ScoreMetric validateTakeOut()
    {
        int hit = 0;
        int total = 0;

        foreach(Item orderItem in orderManager.getOrder())
        {
            foreach(Item bagItem in bagManager.getBagItems())
            {
                if(orderItem.getID() == bagItem.getID())
                {
                    hit++;
                    break;
                }
            }
            total++;
        }

        ScoreMetric temp = new ScoreMetric(hit, total);

        return temp;
    }
}
