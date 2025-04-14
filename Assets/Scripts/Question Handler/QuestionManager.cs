using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] private CheckoutQuestionSO currentQuestion;
    [SerializeField] private CheckoutQuestionSO nextQuestion;
    [SerializeField] private List<CheckoutQuestionSO> allQuestions;
    private int currentIndex = 0;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private Transform answerButtonParent;
    private List<GameObject> currentButtons = new();
    [SerializeField] private GameObject correctIcon;
    [SerializeField] private GameObject wrongIcon;
    [SerializeField] private Button nextQuestionBtn;

    private void Awake()
    {
        nextQuestionBtn.gameObject.SetActive(false);
    }

    private void Start()
    {
        correctIcon.SetActive(false);
        wrongIcon.SetActive(false);
        DisplayQuestions(currentQuestion);
    }

    public void ShowNextQuestion()
    {
        NextIndex();
    }

    private void NextIndex()
    {
        currentIndex++;

        if (currentIndex >= allQuestions.Count)
        {
            Debug.Log("all Questions answerd");

            currentIndex = 0;
        }

        DisplayQuestions(allQuestions[currentIndex]);
        nextQuestionBtn.gameObject.SetActive(false);
    }

    public void DisplayQuestions(CheckoutQuestionSO question)
    {
        wrongIcon.SetActive(false);
        correctIcon.SetActive(false);
        ClearButtons();

        currentQuestion = question;
        targetText.text = $"{question.targetScore}";

        foreach (var option in question.options)
        {
            GameObject btnObj = Instantiate(answerButtonPrefab, answerButtonParent);
            Button btn = btnObj.GetComponent<Button>();
            TextMeshProUGUI btnText = btnObj.GetComponentInChildren<TextMeshProUGUI>();

            btnText.text = option.awnser;

            btn.onClick.AddListener(() => OnAnswerSelected(option));
            currentButtons.Add(btnObj);
        }
    }

    private void OnAnswerSelected(AnswerOption selectedOption)
    {
        if (selectedOption.isCorrect)
        {
            Debug.Log("Correct");
            correctIcon.SetActive(true);
            wrongIcon.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong");
            wrongIcon.SetActive(true);
            correctIcon.SetActive(false);
        }

        foreach (var btn in currentButtons)
        {
            btn.GetComponent<Button>().interactable = false;
            nextQuestionBtn.gameObject.SetActive(true);
        }
    }

    private void ClearButtons()
    {
        foreach (var btn in currentButtons)
        {
            btn.GetComponent<Button>().onClick.RemoveAllListeners();

            Destroy(btn);
        }

        currentButtons.Clear();
    }
}
