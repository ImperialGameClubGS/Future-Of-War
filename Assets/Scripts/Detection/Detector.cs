using System;
using UnityEngine;
using UnityEngine.AI;

public class Detector : MonoBehaviour, IDetector
{
    public event ObjectDetectedHandler OnGameObjectDetectedEvent;
    public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    public Transform CurrentPoint => _patrolPoints[_currentPoint];
    public float DistanceAttack = 3f;
    public float SpeedAttack = 2f;
    public bool isAttack;

    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _bulletPrefab;

    private NavMeshAgent _navMeshAgent;
    private int _currentPoint = 0;
    private bool _isSawPlayer = false;
    private EnemyBase _enemy;
    private IHittable _target;
    private float _timerAttack = 0f;
    private Type _typeEnemy;

    void Start()
    {
        _navMeshAgent = GetComponentInParent<NavMeshAgent>();
        _enemy = GetComponentInParent<EnemyBase>();
        _target = _player.GetComponent<IHittable>();
        _typeEnemy = _enemy.GetType();
    }

    private void Update()
    {

        if (_isSawPlayer)
        {
            switch (_typeEnemy.ToString())
            {
                case "EnemyBase":
                    PlayerHarassment();
                    break;
                case "EnemyShooting":
                    EnemyShooting();
                    break;
                default:
                    break;
            }
        }
        else
        {
            _navMeshAgent.speed = _enemy.RestingSpeed;

            if (HasReached(_navMeshAgent))
            {
                _navMeshAgent.SetDestination(GetNext().position);
            }
            
        }
    }

    private void EnemyShooting()
    {
        _navMeshAgent.SetDestination(_player.position);
        _navMeshAgent.speed = 0.1f;
        _timerAttack += Time.deltaTime;
        if (_timerAttack >= SpeedAttack)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _enemy.transform.TransformPoint(Vector3.forward * 1.5f);
            bullet.transform.rotation = _enemy.transform.rotation;
            _timerAttack = 0f;
        }
    }

    private void PlayerHarassment()
    {
        _navMeshAgent.SetDestination(_player.position);
        _navMeshAgent.speed = _enemy.RunSpeed;
        if (_navMeshAgent.remainingDistance < DistanceAttack)
        {
            _timerAttack += Time.deltaTime;
            if (_timerAttack >= SpeedAttack)
            {
                isAttack = true;
                _target.HitObject(_enemy.Damage);
                _timerAttack = 0f;
            }
            else
            {
                isAttack = false;
            }
        }
    }

    public bool HasReached(NavMeshAgent agent)
    {
        if (!agent.pathPending)
        {

            if (agent.remainingDistance <= agent.stoppingDistance)
            {

                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public Transform GetNext()
    {
        if(_patrolPoints[0] == null)
        {
            return null;
        }
        var point = _patrolPoints[_currentPoint];
        _currentPoint = (_currentPoint + 1) % _patrolPoints.Length;
        return point;
    }

    public void Detect(IDetectableObject detectablePlayer)
    {
        _isSawPlayer = true;
        detectablePlayer.Detected(gameObject);

        OnGameObjectDetectedEvent?.Invoke(gameObject, detectablePlayer.gameObject);
    }

    public void ReleaseDetection(IDetectableObject detectablePlayer)
    {
        _isSawPlayer = false;
        detectablePlayer.DetectionReleased(gameObject);

        OnGameObjectDetectionReleasedEvent?.Invoke(gameObject, detectablePlayer.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsColliderDetectableObject(other, out var detectedPlayer))
        {
            Detect(detectedPlayer);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (IsColliderDetectableObject(other, out var detectedPlayer))
        {
            ReleaseDetection(detectedPlayer);
        }
    }
    private bool IsColliderDetectableObject(Collider coll, out IDetectableObject detectedPlayer)
    {
        detectedPlayer = coll.GetComponent<IDetectableObject>();

        return detectedPlayer != null;
    }

}
