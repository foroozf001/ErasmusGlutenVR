using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialBread : MonoBehaviour
{
    Rigidbody RB;
    [SerializeField] GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "TutorialGroundCollider")
        {
            this.transform.position = new Vector3(-0.2f, 1.1f, -0.2f);
            RB.velocity = Vector3.zero;
        }
        
        if(collision.gameObject.name == "TutorialTarget")
        {
            this.gameObject.SetActive(false);
            Target.gameObject.SetActive(false);
            //TODO:SFX
            //TODO:Text to instruct to wash hands
        }
    }
}
