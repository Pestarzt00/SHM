using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] State _startingState;
    [SerializeField] float _characterSpeed;

    private NavMeshAgent _navMeshAgent;
    private State _state;
    private Vector2 _walkPosition;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _state = _startingState;
    }

    private enum State
    {
        Idle,
        Walk,
        Sleep,
        Busy
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Idle:
                break;
            case State.Walk:
                break;
            case State.Sleep:
                break;
            case State.Busy:
                break;
        }
    }
}
