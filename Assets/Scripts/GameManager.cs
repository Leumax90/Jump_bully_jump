﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float score;
    public Transform startingPoint;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            if (playerControllerScript.doubleSpeed)
            {
                score += 2;
            }
            else
            {
                score++;
            }
            Debug.Log("Score:" + score);
            float startTime = Time.time;
            Debug.Log("startTime:" + startTime);
        }
        
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;
        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        0.5f);
        while (fractionOfJourney < 1)
        {
          
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos,
            fractionOfJourney);
            Debug.Log("fractionOfJourney:" + fractionOfJourney);
            Debug.Log("distanceCovered:" + distanceCovered);
            Debug.Log("startTime:" + startTime);
            Debug.Log("Time.time:" + Time.time);
            yield return null;
        }
        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier",
        1.0f);
        playerControllerScript.gameOver = false;
       
    }



}

