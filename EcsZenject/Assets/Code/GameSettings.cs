using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Data/Game Settings")]
public class GameSettings : ScriptableObject
{
    public float WalkSpeed;
    public float RunSpeed;

    public float CameraSmothing;

    public Vector3 ResetPosition;
}
