using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Ending_Text;

    int player = (int)GameManager.playerState;
    private void Awake()
    {
        StartCoroutine(Final_Score());
    }

    IEnumerator Final_Score()
    {
        if (player == -1)
        {
            Ending_Text.text = "Player 1 has won!";
        }
        else
            Ending_Text.text = "Player 2 has won!";
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(0);
    }
}
