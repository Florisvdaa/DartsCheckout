using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "CheckoutQuestion", menuName = "Darts/Checkout Question")]
public class CheckoutQuestionSO : ScriptableObject
{
    public int targetScore;
    public List<AnswerOption> options = new();
    public string catagory;
}

[Serializable]
public class AnswerOption
{
    public string awnser;
    public bool isCorrect;
}