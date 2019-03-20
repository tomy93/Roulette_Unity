using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckCorrectAnswer : MonoBehaviour
{
    [SerializeField] private QuestionSetup questionSetup;
    [SerializeField] private UnityEvent onCorrect;
    [SerializeField] private UnityEvent onWrong;

    public void CheckAnswer(int index)
    {
        if (index == questionSetup.CorrectAnswer)
        {
            CorrectAnswer();
        }
        else
        {
            BadAnswer();
        }
    }

    private void CorrectAnswer()
    {
        if (onCorrect != null)
        {
            onCorrect.Invoke();
            AudioPlayer.instance.PlayGoodAnswer();
        }
    }

    private void BadAnswer()
    {
        if (onWrong != null)
        {
            onWrong.Invoke();
            AudioPlayer.instance.PlayBadAnswer();
        }
    }
}
