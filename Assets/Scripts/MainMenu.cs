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
        M.text = GameManager.Instance.M.ToString();
        N.text = GameManager.Instance.N.ToString();
    }
    public void AddM()
    {
        GameManager.Instance.M++;
    }
    public void AddN()
    {
        GameManager.Instance.N++;
    }
    public void DecreaseM()
    {
        GameManager.Instance.M--;
    }
    public void DecreaseN()
    {
        GameManager.Instance.N--;
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
