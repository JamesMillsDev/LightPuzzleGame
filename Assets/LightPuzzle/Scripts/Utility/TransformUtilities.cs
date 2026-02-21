using System;
using System.Collections;
using UnityEngine;

namespace LightPuzzle.Utility
{
    public static class TransformUtilities
    {
        public static IEnumerator Rotate(Transform transform, float amount, float time, Action onCompleted = null, Func<float, float> customFactorCalc = null)
        {
            float currentTime = 0f;
            Quaternion initialRot = transform.rotation;
            Quaternion targetRotation = initialRot * Quaternion.Euler(0f, 0f, amount);

            while(currentTime < time)
            {
                float factor = customFactorCalc?.Invoke(currentTime / time) ?? currentTime / time;

                Quaternion rot = Quaternion.Slerp(initialRot, targetRotation, factor);

                transform.rotation = rot;

                yield return null;

                currentTime += Time.deltaTime;
            }

            transform.rotation = targetRotation;
            onCompleted?.Invoke();
        }
    }
}