using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class QuizSettingsManager : MonoBehaviour
{
    public TMP_InputField InputQuestion;
    public TMP_InputField InputAnswer1;
    public TMP_InputField InputAnswer2;
    public TMP_InputField InputAnswer3;
    public TMP_InputField InputAnswer4;
    public Button ButtonApply;
    public Button ButtonClear;

    public static string QuizQuestion = "QuizQuestion";
    public static string QuizAnswer1 = "QuizAnswer1";
    public static string QuizAnswer2 = "QuizAnswer2";
    public static string QuizAnswer3 = "QuizAnswer3";
    public static string QuizAnswer4 = "QuizAnswer4";

    private Dictionary<string, TMP_InputField> AnswerFieldMapping = new Dictionary<string, TMP_InputField>();

    private void Awake()
    {
        ButtonClear.onClick.AddListener(OnButtonClear);
        ButtonApply.onClick.AddListener(OnButtonApply);
        AnswerFieldMapping.Add(QuizAnswer1, InputAnswer1);
        AnswerFieldMapping.Add(QuizAnswer2, InputAnswer2);
        AnswerFieldMapping.Add(QuizAnswer3, InputAnswer3);
        AnswerFieldMapping.Add(QuizAnswer4, InputAnswer4);
    }

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(QuizQuestion))
        {
            InputQuestion.text = PlayerPrefs.GetString(QuizQuestion);
        }

        foreach (var entry in AnswerFieldMapping)
        {
            if (!PlayerPrefs.HasKey(entry.Key)) { continue; }
            entry.Value.text = PlayerPrefs.GetString(entry.Key);
        }
    }

    private void OnButtonApply()
    {
        PlayerPrefs.SetString(QuizQuestion, InputQuestion.text);
        
        foreach(var entry in AnswerFieldMapping)
        {
            if (string.IsNullOrWhiteSpace(entry.Value.text))
            {
                PlayerPrefs.DeleteKey(entry.Key);
            }
            else
            {
                PlayerPrefs.SetString(entry.Key, entry.Value.text);
            }
        }

        GetComponentInParent<SimpleSceneLoader>().LoadSceneVoting();
    }

    private void OnButtonClear()
    {
        foreach(var entry in AnswerFieldMapping)
        {
            PlayerPrefs.DeleteKey(entry.Key);
            entry.Value.text = string.Empty;
        }
        PlayerPrefs.DeleteKey(QuizQuestion);
        InputQuestion.text = string.Empty;
    }
}
