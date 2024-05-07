using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _currentValue;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private bool _isTimer;

    public event Action ValuerChancged;

    public int CurrentValue => _currentValue;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartTimer();

        if (Input.GetMouseButtonDown(1))
            StopTimer();
    }

    public void StartTimer()
    {
        if (_isTimer)
            return;

        _isTimer = true;
        StartCoroutine(Countdown(_delay));
    }

    public void StopTimer()
    {
        _isTimer = false;
        StopCoroutine(Countdown(_delay));
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_isTimer)
        {
            _currentValue++;
            ValuerChancged?.Invoke();
            yield return wait;
        }
    }

}
