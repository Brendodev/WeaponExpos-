using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct FocusParameters
{
    public float offset;
    public float animationVelocity;
}
public class SelectedAnimation : MonoBehaviour
{

    [SerializeField] private FocusParameters _focusParameters;

    private Vector3 focusPosition;
    private Coroutine currentAnimation;
    private Vector3 startPosition;
    

    private void Start()
    {
        startPosition = transform.position;
    }

    public void GetFocus()
    {
        GetAnimation();
    }
    
    public void LoseFocus()
    {
        LoseAnimation();
    }
    private void GetAnimation()
    {
        if(currentAnimation != null)
            StopCoroutine(currentAnimation);

        focusPosition = Vector3.zero + new Vector3(startPosition.x, startPosition.y + _focusParameters.offset, startPosition.z);
        currentAnimation = StartCoroutine(AnimateMove(Vector3.zero, focusPosition, _focusParameters.animationVelocity));
    }

    private void LoseAnimation()
    {
        if(currentAnimation != null)
            StopCoroutine(currentAnimation);

        focusPosition = Vector3.zero +new Vector3(startPosition.x, startPosition.y + _focusParameters.offset, startPosition.z);;
        currentAnimation = StartCoroutine(AnimateMove(focusPosition, Vector3.zero, _focusParameters.animationVelocity));
        
    }

    IEnumerator AnimateMove(Vector3 originPosition, Vector3 targetPosition, float velocity = 1)
    {

        Vector3 currentPosition = transform.position;
        
        float totalDistance = (targetPosition - originPosition).magnitude;
        float currentDistance = (currentPosition - originPosition).magnitude;

        float lerpStep = currentDistance / totalDistance;

        while (lerpStep < 1)
        {
            lerpStep += Time.deltaTime * velocity;
            transform.position = Vector3.Lerp(originPosition, targetPosition, lerpStep);
            yield return new WaitForEndOfFrame();
            
        }

        transform.position = targetPosition;
    }
    
}
