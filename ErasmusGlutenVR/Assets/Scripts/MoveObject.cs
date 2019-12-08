using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField][Range(0.01f, 1.0f)] float thrust;
    [SerializeField] Vector3 direction;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.AddForce(direction.normalized.x * thrust, direction.normalized.y * thrust, direction.normalized.z * thrust, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigidBody.AddForce(direction.normalized * thrust);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (other.gameObject.layer == 11)
        {
            Destroy(this.gameObject);
        }
    }
}
