using UnityEngine;

public class InputDescktop : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _timer.StartTimer();

        if (Input.GetMouseButtonDown(1))
            _timer.StopTimer();
    }
}
