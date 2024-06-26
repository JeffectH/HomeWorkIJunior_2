using System;
using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private int _currentValue;
    [SerializeField] private float _delay = 0.5f;

    private int _inputValue = 0;

    private Coroutine _coroutine;

    public event Action<int> ValuerChancged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_inputValue))
        {
            if (_coroutine == null)
            {
                Restart();
            }
            else
            {
                Stop();
            }
        }
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
            ValuerChancged?.Invoke(_currentValue++);
            yield return wait;
        }
    }

}
