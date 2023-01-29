using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject dummyRobot;
    [SerializeField] private TakeOutContainer takeOut;

    [SerializeField] private GameObject orderRequest;
    [SerializeField] private GameObject levelPassed;
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject defeatedText;
    [SerializeField] private GameObject rating_1;
    [SerializeField] private GameObject rating_2;
    [SerializeField] private GameObject rating_3;
    [SerializeField] private GameObject youLose;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject retry;
    [SerializeField] private Text commentBox;

    [SerializeField] private Animator tablePopUp;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
         
    }

    public void runNextLevel()
    {
        Loader.NextLevel();
    }

    public void resetLevel()
    {
        Loader.ReloadLevel();
    }

    public void handleVictory()
    {
        dummyRobot.SetActive(false);
        victoryUIsetUp();
        ScoreMetric score = takeOut.validateTakeOut();
        ScoreboardRegister.scores.Add(score);

        int hits = score.getHits();
        int total = score.getTotal();
        float hitRate = score.getHitRate();

        if (hitRate >= 100f)
        {
            victoryText.SetActive(true);
            rating_1.SetActive(true);
            rating_2.SetActive(true);
            rating_3.SetActive(true);
            nextLevel.SetActive(true);
            commentBox.text = "Hit take-out item(s): " + hits + "\nTotal take-out item(s): " + total + "\nScore: " + hitRate + "\nCustomer review: Brilliant service!";
        }
        else if(50f <= hitRate && hitRate <= 100f)
        {
            defeatedText.SetActive(true);
            rating_1.SetActive(true);
            rating_2.SetActive(true);
            nextLevel.SetActive(true);
            commentBox.text = "Hit take-out item(s): " + hits + "\nTotal take-out item(s): " + total + "\nScore: " + hitRate + "\nCustomer review: Got me some wrong item(s), but acceptable.";
        }
        else if (25f <= hitRate && hitRate <= 50f)
        {
            defeatedText.SetActive(true);
            rating_1.SetActive(true);
            nextLevel.SetActive(true);
            commentBox.text = "Hit take-out item(s): " + hits + "\nTotal take-out item(s): " + total + "\nScore: " + hitRate + "\nCustomer review: Got me many wrong item(s). Bad service :(";
        }
        else if (0f <= hitRate && hitRate <= 25f)
        {
            defeatedText.SetActive(true);
            youLose.SetActive(true);
            retry.SetActive(true);
            commentBox.text = "Hit take-out item(s): " + hits + "\nTotal take-out item(s): " + total + "\nScore: " + hitRate + "\nCustomer review: Very bad service.";
        }
        else
        {

        }
    }

    private void victoryUIsetUp()
    {
        //tabletUI.SetActive(true);
        tablePopUp.SetBool("pop", true);
        orderRequest.SetActive(false);
        levelPassed.SetActive(true);
        victoryText.SetActive(false);
        defeatedText.SetActive(false);
        rating_1.SetActive(false);
        rating_2.SetActive(false);
        rating_3.SetActive(false);
        youLose.SetActive(false);
        nextLevel.SetActive(false);
        retry.SetActive(false);
    }
}
