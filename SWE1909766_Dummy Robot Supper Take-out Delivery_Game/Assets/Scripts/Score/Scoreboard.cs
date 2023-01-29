using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private Text scoreBoardBox;
    [SerializeField] private Animator tablePopUp;
    [SerializeField] private AudioSource victoryYaySoundEffect;

    private Queue<ScoreMetric> scores;
    private int i = 0;

    // Start is called before the first frame update
    
    void Awake()
    {
        scores = new Queue<ScoreMetric>();
    }
    
    void Start()
    {
        tablePopUp.SetBool("pop", true);
        victoryYaySoundEffect.Play();

        scores.Clear();

        foreach(ScoreMetric score in ScoreboardRegister.scores)
        {
            scores.Enqueue(score);
        }

        Continue();
    }

    public void Continue()
    {
        if (scores.Count == 0)
        {
            i = 0;
            Loader.EndGame();
            return;
        }
        else
        {
            i++;
            ScoreMetric score = scores.Dequeue();
            scoreBoardBox.text = "Scores.\n[Level_" + i + "]\n Hit take-out item(s): " + score.getHits() + "\nTotal take-out item(s): " + score.getTotal() + "\nScore: " + score.getHitRate();
        }
    }

}
