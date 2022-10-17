using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunAnimations : MonoBehaviour
{
    private Animation _shotGunAnim;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _shotGunAnim  = GetComponent<Animation>();
        _animator = GameObject.Find("DROBRUKIBSTATIC").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("Shot",true);
            if (_shotGunAnim != null)
            {
                _shotGunAnim.clip = _shotGunAnim.GetClip("reload");
                _shotGunAnim.Play();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Shot", false);
        }
    }
}
