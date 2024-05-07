using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.ValuerChancged += UpdateView;
    }

    private void OnDisable()
    {
        _timer.ValuerChancged -= UpdateView;
    }

    private void UpdateView() =>
        _countdownText.text = _timer.CurrentValue.ToString();
}
