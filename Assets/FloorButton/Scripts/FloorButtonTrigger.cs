using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonTrigger : MonoBehaviour
{
    [SerializeField] FloorButtonAnimator btnAnim;
    private bool isActivated;
    public bool IsActivated
    {
        get { return isActivated; }
        private set { isActivated = value; }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isCharOrMovableObj(other))
        {
            btnAnim.Activate();
            ToggleBtn(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (isCharOrMovableObj(other))
        {
            btnAnim.Desactivate();
            ToggleBtn(false);
        }
    }

    private bool isCharOrMovableObj(Collider other)
    {
        Gravity gravityComp = other.transform.GetComponent<Gravity>();
        CharacterController charController = other.transform.GetComponent<CharacterController>();
        return charController || gravityComp;
    }

    private void ToggleBtn(bool activation)
    {
        if (isActivated != activation)
            isActivated = activation;
    }

}
