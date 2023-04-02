using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]

public class PlayerShooter : MonoBehaviour
{
    public void OnShoot()
    {
        Debug.Log("Shoot");
    }
}
