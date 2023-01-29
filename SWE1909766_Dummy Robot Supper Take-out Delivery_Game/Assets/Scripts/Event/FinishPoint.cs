using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private EventManager eventManger;
    [SerializeField] private AudioSource talkingSoundEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            talkingSoundEffect.Play();
            eventManger.handleVictory();           
        }
    }
}
