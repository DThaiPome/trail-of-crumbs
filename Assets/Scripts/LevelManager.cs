﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public static bool isGameOver;

    [SerializeField]
    private string nextLevel;
    [SerializeField]
    private Text gameOverText;
    public bool canBreakPods;
    public Transform player;
    private Vector3 checkpointPosition;

    void Start()
    {
        isGameOver = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        checkpointPosition = player.position;
    }

    public void LevelLost()
    {
        this.SetGameOverText("YOU GOT CAUGHT");

        isGameOver = true;

        Invoke("LoadThisLevel", 2);
    }

    public void LevelWon()
    {
        this.SetGameOverText("OBJECTIVE COMPLETE");

        isGameOver = true;

        Invoke("LoadNextLevel", 2);
    }

    public void SetGameOverText(string text)
    {
        this.gameOverText.text = text;
        gameOverText.enabled = true;
    }

    private void LoadThisLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        this.WarpPlayer(this.checkpointPosition);
        isGameOver = false;
        CellPrimeBehavior cellPrime = FindObjectOfType<CellPrimeBehavior>();
        if (cellPrime != null)
        {
            cellPrime.Checkpoint();
        }

        if (canBreakPods)
        {
            PodBreak.ResetPodCache();
        }

        FindObjectOfType<GrappleHandController>().DeactivatePowerups();

        ConductorBehavior cb = FindObjectOfType<ConductorBehavior>();
        if (cb != null)
        {
            cb.GameOver();
        }

        FindObjectOfType<GrappleHandController>().controlState = ControlState.Retracting;

        DisableGameOverText();
    }

    private void WarpPlayer(Vector3 newPos)
    {
        CharacterController cc = this.player.gameObject.GetComponent<CharacterController>();
        cc.enabled = false;
        this.player.position = newPos;
        cc.enabled = true;
    }

    public void SetCheckPoint(Vector3 position)
    {
        checkpointPosition = position;
        SetGameOverText("CHECKPOINT REACHED");
        Invoke("DisableGameOverText", 2);
    }

    private void DisableGameOverText()
    {
        gameOverText.enabled = false;
    }

    private void LoadNextLevel()
    {
        if (this.nextLevel != "")
        {
            SceneManager.LoadScene(this.nextLevel);
        }
    }
}
