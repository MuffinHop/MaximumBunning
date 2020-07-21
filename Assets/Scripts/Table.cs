using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furniture
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
                Destroy(contact.thisCollider);
                var bunRigid = collision.gameObject.GetComponent<Rigidbody>();
                var tableRigid = GetComponent<Rigidbody>();
                var bunVelocity = bunRigid.velocity;
                tableRigid.AddTorque(new Vector3(bunVelocity.x * 0.5f, UnityEngine.Random.Range(4f, 16f), bunVelocity.z * 0.5f ),ForceMode.Impulse);
            }
        }
    }
    void Update()
    {
        var eulerAnglesNow = transform.up;
        if (!_pointsGiven)
        {
            if (Vector3.Dot(eulerAnglesNow, _eulerAnglesThen) < 0.94f)
            {
                _points.ScorePoints.Invoke(100); 
                _pointsGiven = true;
                Instantiate(_pointScalerPrefab, transform.position + new Vector3(0.0f, 4f, 0.0f), Quaternion.Euler(90f,0f,0f));
                Invoke("Explosion", 0.333f);
            }
        }
        else if(_fadeOut)
        {
            transform.localScale /= 1.05f;
        }
    }
}
