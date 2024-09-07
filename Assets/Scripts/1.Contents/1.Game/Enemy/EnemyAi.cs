using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    Vector3 _Startposition;
    Quaternion _StartRotation;
    

    [SerializeField] float _Trackingrange = 10f;
    [SerializeField] float _MoveSpeed = 5.0f;
    [SerializeField] Transform Target;
    float _distance;
    Vector3 _direction;
    Quaternion _lookRotQuat;
    private void Awake()
    {
        _Startposition = transform.position;
        _StartRotation = transform.rotation;
    }

    void Start()
    {
        
    }


    void Update()
    {        
        _direction = Target.position - transform.position;
        _distance = _direction.magnitude;
        _lookRotQuat = Quaternion.LookRotation(_direction);

        if (_distance < 10.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotQuat, Time.deltaTime * 10);  
        }
        if (_distance < 5.0f)
        {
            transform.Translate(Vector3.forward* _MoveSpeed * Time.deltaTime);     
        }

        if (_distance > 10.0f)
        {
            Vector3 _dir = _Startposition - transform.position;
            float _dis = _dir.magnitude;
            //if(_dir.normalized != Vector3.zero)
                       
            if (_dis > 0.5f)
            {
                Quaternion _quat = Quaternion.LookRotation(_dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, _quat, Time.deltaTime * 10);
                transform.Translate(Vector3.forward * _MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, _StartRotation, Time.deltaTime * 10);
            }

        }



    }
}
