using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevel : MonoBehaviour
{
    [SerializeField] private FloorButtonTrigger[] levelBtns;
    DoorAnimator doorAnim;

    private void Start()
    {
        doorAnim = GetComponent<DoorAnimator>();
    }

    private void Update()
    {
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        int activatedButtons = 0;
        foreach (FloorButtonTrigger button in levelBtns)
        {
            if (button.IsActivated)
                activatedButtons++;
            if (activatedButtons == levelBtns.Length)
                doorAnim.Activate();
            else
                doorAnim.Desactivate();

        }
    }
}
