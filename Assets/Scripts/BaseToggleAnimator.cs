using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseToggleAnimator : MonoBehaviour
{
    private Animation anim;
    [SerializeField] private AnimationClip activated;
    [SerializeField] private AnimationClip desactivated;

    private void Start()
    {
        anim = this.GetComponent<Animation>();
    }

    public void Activate()
    {
        anim.clip = activated;
        anim.Play();
    }
    public void Desactivate()
    {
        anim.clip = desactivated;
        anim.Play();
    }
}
