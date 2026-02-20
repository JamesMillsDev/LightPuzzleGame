using System;

public interface IRotatable
{
    public float RotateAmount { get; }

    public float RotateTime { get; }

    public Func<float, float> GetSmoothingFunction();
}