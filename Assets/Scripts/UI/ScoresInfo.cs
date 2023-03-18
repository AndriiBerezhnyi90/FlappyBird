using UnityEngine;
using TMPro;
using System;

public class ScoresInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreInfo;

    public void SetAmount(int value)
    {
        _scoreInfo.text = Convert.ToString(value);
    }
}