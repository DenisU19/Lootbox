using UnityEngine;
using UnityEngine.Events;

public class DropMovement : MonoBehaviour
{
    [SerializeField] [Range(800f, 900f)]
    private float _startMovementSpeed;
    [SerializeField] [Range(35f, 45f)]
    private float _stopScrollerCoefficient;

    private float _currentMovementSpeed;

    public UnityEvent OnMovementStopedEvent;

    private void OnEnable()
    {
        _currentMovementSpeed = _startMovementSpeed;
    }

    private void Update()
    {
        DropMover();
    }

    public void DropMover()
    {
        _currentMovementSpeed = Mathf.MoveTowards(_currentMovementSpeed, 0, _stopScrollerCoefficient * Time.deltaTime);

        transform.Translate(new Vector2(-_currentMovementSpeed, 0) * Time.deltaTime);

        if(_currentMovementSpeed <= 0)
        {
            OnMovementStopedEvent?.Invoke();
            _currentMovementSpeed = _startMovementSpeed;
            enabled = false;
        }
    }

    public void GetSomeSpeed()
    {
        _currentMovementSpeed += _stopScrollerCoefficient;
    }
}
