using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonTrigger : MonoBehaviour
{
    [SerializeField] FloorButtonAnimator btnAnim;
    public bool isActivated
    {
        get { return this.isActivated; }
        private set { this.isActivated = value; }
    }

    private void OnCollisionStay(Collision other)
    {
        Gravity gravityComp = other.transform.GetComponent<Gravity>();
        CharacterController charController = other.transform.GetComponent<CharacterController>();

        if (charController || gravityComp)
        {
            btnAnim.Activate();
            isActivated = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        Gravity gravityComp = other.transform.GetComponent<Gravity>();
        CharacterController charController = other.transform.GetComponent<CharacterController>();

        if (charController || gravityComp)
        {
            btnAnim.Desactivate();
            isActivated = false;
        }
    }
}
