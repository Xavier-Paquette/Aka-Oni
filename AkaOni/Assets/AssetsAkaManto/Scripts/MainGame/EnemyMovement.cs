using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _pursuitSpeed = 1.4f;
    [SerializeField] private float _wanderSpeed = 0.8f;
    private float _currentSpeed = 3;
    [SerializeField] private float _directionChangeInterval = 3;
    [SerializeField] private bool followPlayer = true;
    private Coroutine _moveCoroutine;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Transform _targetTransform = null;
    private Vector3 _endPosition;
    private float _currentAngle = 0;
    private CircleCollider2D _circleCollider;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private GameObject _bgAudio;
    void Start()
    {
        
        _anim = GetComponent<Animator>();
        _currentSpeed = _wanderSpeed;
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        
        StartCoroutine(WanderRoutine());


    }
    public IEnumerator WanderRoutine()
    {
        while (true)
        {
            ChooseNewEndpoint();
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(Move(_rb, _currentSpeed));
            yield return new WaitForSeconds(_directionChangeInterval);
        }
    }
    void ChooseNewEndpoint()
    {
        Vector3 curPos = transform.position;
        _currentAngle += Random.Range(0, 360);
        _currentAngle = Mathf.Repeat(_currentAngle, 360);
        _endPosition += Vector3FromAngle(_currentAngle);
        if (_endPosition.x < curPos.x)
        {
            _anim.SetBool("isFacingEast", false);
            _anim.SetBool("isFacingNorth", false);
            _anim.SetBool("isFacingSouth", false);
            _anim.SetBool("isFacingWest", true);
        }
        if (_endPosition.x > curPos.x)
        {
            _anim.SetBool("isFacingEast", true);
            _anim.SetBool("isFacingNorth", false);
            _anim.SetBool("isFacingSouth", false);
            _anim.SetBool("isFacingWest", false);
        }
        if (_endPosition.y < curPos.y) {
            _anim.SetBool("isFacingEast", false);
            _anim.SetBool("isFacingNorth", false);
            _anim.SetBool("isFacingSouth", true);
            _anim.SetBool("isFacingWest", false);
        }
        if (_endPosition.y > curPos.y)
        {
            _anim.SetBool("isFacingEast", false);
            _anim.SetBool("isFacingNorth", true);
            _anim.SetBool("isFacingSouth", false);
            _anim.SetBool("isFacingWest", false);
        }

    }
    Vector3 Vector3FromAngle(float inputAngleDegrees)
    {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(inputAngleRadians),
        Mathf.Sin(inputAngleRadians), 0);
    }
    public IEnumerator Move(Rigidbody2D rbToMove, float speed)
    {
        Vector3 curPos = transform.position;
        float remainingDistance = (transform.position -
        _endPosition).sqrMagnitude;
        while (remainingDistance > float.Epsilon)
        {
            if (_targetTransform != null)
            {
                _endPosition = _targetTransform.position;
                if (_endPosition.x < curPos.x)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", true);
                }
                if (_endPosition.x > curPos.x)
                {
                    _anim.SetBool("isFacingEast", true);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                if (_endPosition.y < curPos.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", true);
                    _anim.SetBool("isFacingWest", false);
                }
                if (_endPosition.y > curPos.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", true);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
            }
            if (rbToMove != null)
            {
                
                Vector3 newPosition = Vector3.MoveTowards(rbToMove.position,
                _endPosition, speed * Time.deltaTime);
                _rb.MovePosition(newPosition);
                if (_endPosition.x < curPos.x)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", true);
                }
                if (_endPosition.x > curPos.x)
                {
                    _anim.SetBool("isFacingEast", true);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                if (_endPosition.y < curPos.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", false);
                    _anim.SetBool("isFacingSouth", true);
                    _anim.SetBool("isFacingWest", false);
                }
                if (_endPosition.y > curPos.y)
                {
                    _anim.SetBool("isFacingEast", false);
                    _anim.SetBool("isFacingNorth", true);
                    _anim.SetBool("isFacingSouth", false);
                    _anim.SetBool("isFacingWest", false);
                }
                remainingDistance = (transform.position - _endPosition).sqrMagnitude;
            }
            yield return new WaitForFixedUpdate();
        }
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision is CapsuleCollider2D && 
        followPlayer)
        {
            //chase music start
            _bgAudio.SetActive(false);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            _currentSpeed = _pursuitSpeed;
            _targetTransform = collision.gameObject.transform;
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _moveCoroutine = StartCoroutine(Move(_rb, _currentSpeed));
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            //chase music stop
            _bgAudio.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Stop();
            _currentSpeed = _wanderSpeed;
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }
            _targetTransform = null;
        }
    }
    void OnDrawGizmos()
    {
        if (_circleCollider != null)
        {
            Gizmos.DrawWireSphere(transform.position,
            _circleCollider.radius);
            Debug.DrawLine(_rb.position, _endPosition, Color.red);
        }
    }

    public void ResetPosition() {
        
        transform.position = spawnPoint;
    }

}
