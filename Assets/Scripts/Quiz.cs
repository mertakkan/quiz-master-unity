using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI questionText;

    [SerializeField]
    QuestionSO question;

    [SerializeField]
    GameObject[] answerButtons;

    int correctAnswerIndex;

    [SerializeField]
    Sprite defaultAnswerSprite;

    [SerializeField]
    Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if (index == question.getCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.getCorrectAnswerIndex();
            questionText.text =
                "Sorry, but the correct answer is option "
                + (question.getCorrectAnswerIndex() + 1)
                + ": "
                + question.GetAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
