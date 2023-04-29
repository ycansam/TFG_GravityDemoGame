using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonAnimator : MonoBehaviour
{
    private Animation anim;
    [SerializeField] private AnimationClip activatedBtn;
    [SerializeField] private AnimationClip desactivatedBtn;



    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    public void Activate()
    {
        anim.clip = activatedBtn;
        anim.Play();
    }
    public void Desactivate()
    {
        anim.clip = desactivatedBtn;
        anim.Play();
    }

}
