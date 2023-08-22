using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButtonAnimator : MonoBehaviour
{

    [SerializeField]
    private Transform activatedPoint;

    [SerializeField]
    private Transform desactivatedPoint;
    [SerializeField]
    private Transform flootButton;

    public void Activate()
    {
        StartCoroutine(MoveButton(activatedPoint.position));
    }
    public void Desactivate()
    {
        StartCoroutine(MoveButton(desactivatedPoint.position));
    }

    IEnumerator MoveButton(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = flootButton.position;
        while (timeElapsed < 0.5f)
        {
            flootButton.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / 0.5f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        flootButton.position = targetPosition;
    }

}
