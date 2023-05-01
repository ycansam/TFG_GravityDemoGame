using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonTrigger : MonoBehaviour
{
    FloorButtonAnimator btnAnim;
    BtnColor btnColor;
    [SerializeField] bool requiresColor = false;
    private bool isActivated;
    public bool IsActivated
    {
        get { return isActivated; }
        private set { isActivated = value; }
    }
    private void Start()
    {
        btnColor = GetComponentInParent<BtnColor>();
        btnAnim = GetComponentInParent<FloorButtonAnimator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (isCharOrMovableObj(other))
            if (!requiresColor)
                ActivateBtn();
            else if (HasMovableObjectSameColorAsBtn(other))
                ActivateBtn();
    }

    private void ActivateBtn()
    {
        btnAnim.Activate();
        ToggleBtn(true);
        return;
    }

    private void OnTriggerExit(Collider other)
    {
        if (isCharOrMovableObj(other) && isActivated)
            DesactivateBtn();
    }
    private void DesactivateBtn()
    {
        btnAnim.Desactivate();
        ToggleBtn(false);
        return;
    }
    private bool HasMovableObjectSameColorAsBtn(Collider other)
    {
        MovableObjectColor objectColor = other.transform.GetComponent<MovableObjectColor>();
        return objectColor && BtnColor.color == objectColor.Color;
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
