using System.Collections;
using System;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    [SerializeField] private int _currentNumber;
    [SerializeField] private int _minNumber = 0;

    [SerializeField] private TextMeshProUGUI _numbersText;

    [SerializeField] private bool _isIncreaseNumbers = false;

    private WaitForSeconds wait;

    private void Awake()
    {
        _numbersText.text = _minNumber.ToString();
        wait = new WaitForSeconds(_delay);
    }

    private IEnumerator IncreaseSeconds()
    {
        _currentNumber = Int32.Parse(_numbersText.text);

        while (true)
        {
            yield return wait;
            DisplayIncreament(++_currentNumber);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isIncreaseNumbers)
            {
                StopAllCoroutines();
                _isIncreaseNumbers = false;
            }
            else
            {
                StartCoroutine(IncreaseSeconds());
                _isIncreaseNumbers = true;
            }
        }
    }

    private void DisplayIncreament(int currentSecond)
    {
        _numbersText.text = currentSecond.ToString();
    }
}