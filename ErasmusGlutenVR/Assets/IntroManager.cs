using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    [SerializeField] GameObject girl;
    [SerializeField] GameObject glutenfoodtutorial;
    [SerializeField] GameObject tutorialTarget;


    // Start is called before the first frame update
    void Start()
    {
        ThrowingTutorial();
    }

    // Update is called once per frame
    void Update()
    {





        if (GameManager.Instance.GameState == true)
        {
            girl.SetActive(true);
        }
    }

    void ThrowingTutorial()
    {
        glutenfoodtutorial.SetActive(true);
        tutorialTarget.SetActive(true);
    }

}
