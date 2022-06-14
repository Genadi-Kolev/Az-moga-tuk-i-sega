using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text M;
    [SerializeField]
    private TMP_Text N;

    private void Update()
    {
        M.text = GameManager.Instance.m.ToString();
        N.text = GameManager.Instance.n.ToString();
    }
    public void AddM()
    {
        GameManager.Instance.m++;
    }
    public void AddN()
    {
        GameManager.Instance.n++;
    }
    public void DecreaseM()
    {
        GameManager.Instance.m--;
    }
    public void DecreaseN()
    {
        GameManager.Instance.n--;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
