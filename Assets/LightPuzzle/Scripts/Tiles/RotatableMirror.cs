using System;
using LightPuzzle.Utility;
using UnityEngine;

namespace LightPuzzle.Tiles
{
    public class RotatableMirror : Mirror, IRotatable
    {
        public float RotateAmount => 90f;

        public float RotateTime => this.rotationTime;

        [SerializeField] private AnimationCurve smoothingCurve;
        [SerializeField] private float rotationTime = 1f;

        public Func<float, float> GetSmoothingFunction() => time => this.smoothingCurve.Evaluate(time);

        protected override void OnInteracted()
        {
            this.IsInteractable = false;
            StartCoroutine(
                TransformUtilities.Rotate(this.transform, this.RotateAmount, this.RotateTime,
                    () => this.IsInteractable = true,
                    GetSmoothingFunction()
                )
            );
        }
    }
}