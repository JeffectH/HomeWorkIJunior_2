using TMPro;
using UnityEngine;

public class CountdownView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private Countdown _countdown;

    private void OnEnable()
    {
        _countdown.ValuerChancged += UpdateView;
    }

    private void OnDisable()
    {
        _countdown.ValuerChancged -= UpdateView;
    }

    private void UpdateView(int value) => _countdownText.text = value.ToString();
}
