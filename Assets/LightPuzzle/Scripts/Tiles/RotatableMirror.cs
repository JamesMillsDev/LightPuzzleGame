using System;
using System.Data;
using UnityEngine;

public class RotatableMirror : Mirror, IRotatable
{
    public float RotateAmount => 90f;

    public float RotateTime => rotationTime;

    [SerializeField] private AnimationCurve smoothingCurve;
    [SerializeField] private float rotationTime = 1f;

    public Func<float, float> GetSmoothingFunction() => (float time) => smoothingCurve.Evaluate(time);

    protected override void OnInteracted()
    {
        IsInteractable = false;
        StartCoroutine(
            TransformUtilities.Rotate(
                transform, RotateAmount, RotateTime,
                () => IsInteractable = true,
                GetSmoothingFunction()
            )
        );
    }
}