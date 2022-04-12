using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private CapsuleCollider _collider;
    [SerializeField]
    private AnimationCurve _jumpPowerCurve;
    [SerializeField]
    private float _speed = 500f;
    [SerializeField]
    private float _rotationSpeed = 0f;

    private Locomotion _locomotion = new Locomotion();
    private float _minJumpTimer;

    

    private void Awake()
    {
        _locomotion.Setup(transform, _collider, _jumpPowerCurve, _rotationSpeed, _speed, _rigidbody);
    }

    private void Update()
    {
       

        _locomotion.Tick(Time.deltaTime);

        if (_locomotion.IsGrounded && Input.GetKeyDown(KeyCode.Space))     //<-- jump down button check
        {
            _locomotion.IsJumping = true;
            _minJumpTimer = 0.1f;
        }

        if (_minJumpTimer > 0)
            _minJumpTimer -= Time.deltaTime;

        if (_locomotion.IsJumping && (_minJumpTimer > 0f || Input.GetKey(KeyCode.Space)))        //<-- jump is beeing held
        {
            _locomotion.NormalizedJump += Time.deltaTime * 5f;
        }
        else
        {
            _locomotion.IsJumping = false;
            _locomotion.NormalizedJump = 0f;
        }

    }

    private void FixedUpdate()
    {
        //get the input direction
        Vector3 targetDirection = Vector3.zero;
        targetDirection.z = Input.GetAxis("Vertical");
        targetDirection.x = Input.GetAxis("Horizontal");

        _locomotion.Move(targetDirection.normalized); //<-- normalize it since we use the debug axis, (wont be needed for touchpad)
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hej1");
        CameraShaker.shouldShake = true;

        if (gameObject.CompareTag("Enemy"))
        {
        
        
        
        Debug.Log("hej2");

        }
    }

}