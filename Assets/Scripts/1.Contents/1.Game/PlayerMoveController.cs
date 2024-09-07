using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{

    CharacterController _characterController;
    Vector3 _MoveVelocity;
    [SerializeField] Transform _Cam;
    [SerializeField] Transform _CamTartget;
    [SerializeField] float _CamDistance = 3.0f;
    [SerializeField] Animator _CharacterAnim;
    [SerializeField] float _MoveSpeed = 8.0f;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        _MoveVelocity = new Vector3(hInput * _MoveSpeed, 0, vInput * _MoveSpeed);
        _characterController.Move(_MoveVelocity * Time.deltaTime);
        if (_MoveVelocity.normalized != Vector3.zero)
            transform.forward = _MoveVelocity.normalized;
        _Cam.position = _CamTartget.position - _Cam.forward * _CamDistance;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {           
            _CharacterAnim.SetBool("isRun",true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            _CharacterAnim.SetBool("isRun",false);
        }

    }
}
