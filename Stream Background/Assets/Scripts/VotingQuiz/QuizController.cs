using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuizController : MonoBehaviour
{
    public TMP_Text TextQuestion;
    public List<TMP_Text> TextAnswerList;

    public List<GameObject> AnswerGoList;

    public void RefreshQuiz()
    {
        List<string> answerKeys = new List<string>();
        answerKeys.Add(QuizSettingsManager.QuizAnswer1);
        answerKeys.Add(QuizSettingsManager.QuizAnswer2);
        answerKeys.Add(QuizSettingsManager.QuizAnswer3);
        answerKeys.Add(QuizSettingsManager.QuizAnswer4);

        TextQuestion.text = "";
        if (PlayerPrefs.HasKey(QuizSettingsManager.QuizQuestion))
        {
            TextQuestion.text = "Q: " + PlayerPrefs.GetString(QuizSettingsManager.QuizQuestion);
        }

        for (int i = 0; i < 4; i++)
        {
            if (!PlayerPrefs.HasKey(answerKeys[i]))
            {
                AnswerGoList[i].SetActive(false);
                continue;
            }
            AnswerGoList[i].SetActive(true);
            TextAnswerList[i].text = PlayerPrefs.GetString(answerKeys[i]);
        }
    }
}
