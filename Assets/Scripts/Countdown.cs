using System;
using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public event Action ValuerChancged;
    public int CurrentValue => _currentValue;

    [SerializeField] private int _currentValue;
    [SerializeField] private float _delay = 0.5f;

    private int _startInputValue = 0;
    private int _stopInputValue = 1;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_startInputValue))
            Restart();

        if (Input.GetMouseButtonDown(_stopInputValue))
            Stop();
    }

    public void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = null;
    }

    public void Restart()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Work(_delay));
    }

    private IEnumerator Work(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _currentValue++;
            ValuerChancged?.Invoke();
            yield return wait;
        }
    }

}
