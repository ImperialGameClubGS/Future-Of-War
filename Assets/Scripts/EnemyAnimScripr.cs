using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimScripr : MonoBehaviour
{
    private Animator animator;
    private Detector detector;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        detector =transform.parent.GetChild(1).GetComponent<Detector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detector.isAttack)
        {
            animator.SetBool("Attack", true);
            Debug.Log("Attack");
        }
        else
        {
            animator.SetBool("Attack",false);
        }
    }
}
