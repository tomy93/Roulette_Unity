using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Image[] checkCorrect;
    [SerializeField] private Image[] checkCorrect_copy;
    [SerializeField] private Image[] checkIncorrect;
    [SerializeField] private Image[] checkIncorrect_copy;

    [SerializeField] private int currentQuestion = 0;
    [SerializeField] private int corrects = 0;
    [SerializeField] private UnityEvent onEndGameWin;
    [SerializeField] private UnityEvent onEndGameLose;
    [SerializeField] private UnityEvent onBackToRoulette;

    private void Awake()
    {
        HideAll();
    }

    public void HideAll()
    {
        currentQuestion = 0;
        corrects = 0;
        for (int i = 0; i < checkCorrect.Length; i++)
        {
            checkCorrect[i].gameObject.SetActive(false);
            checkIncorrect[i].gameObject.SetActive(false);
            checkCorrect_copy[i].gameObject.SetActive(false);
            checkIncorrect_copy[i].gameObject.SetActive(false);
        }
    }

    public void CorrectAnswer()
    {
        checkCorrect[currentQuestion].gameObject.SetActive(true);
        checkCorrect_copy[currentQuestion].gameObject.SetActive(true);
        currentQuestion++;
        corrects++;
    }

    public void IncorrectAnswer()
    {
        checkIncorrect[currentQuestion].gameObject.SetActive(true);
        checkIncorrect_copy[currentQuestion].gameObject.SetActive(true);
        currentQuestion++;
    }

    public void ShowWinOrEnd()
    {
        if (currentQuestion == 3)
        {
            if (corrects >= 2)
            {
                HideAll();
                AudioPlayer.instance.PlayWin();
                if (onEndGameWin != null)
                {
                    onEndGameWin.Invoke();
                    Debug.Log("win");
                }
            }
            else
            {
                HideAll();
                AudioPlayer.instance.PlayLose();
                if (onEndGameLose != null)
                {
                    onEndGameLose.Invoke();
                    Debug.Log("lose");
                }
            }
        }
        else
        {
            if (onBackToRoulette != null)
            {
                onBackToRoulette.Invoke();
                Debug.Log("onBackToRoulette");
            }
        }

    }

}
