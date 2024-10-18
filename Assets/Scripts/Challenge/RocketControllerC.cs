using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private float _movementDirection;
    
    private readonly float ENERGY_TURN = 0.5f;
    private readonly float ENERGY_BURST = 2f;

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystemC>();
        _rocketMovement = GetComponent<RocketMovementC>();

    }
    
    private void FixedUpdate()
    {
        if (!_isMoving) return;
        
        if(!_energySystem.UseEnergy(Time.fixedDeltaTime * ENERGY_TURN)) return;
        
        _rocketMovement.ApplyMovement(_movementDirection);
    }

    private void OnMove(InputValue value)
    {
        float f = 0;
        if (value.Get().ToString() == "(-1.00, 0.00)")
        {
            f = -1;
        } else if(value.Get().ToString() == "(1.00, 0.00)")
        {
            f = 1;
        }

        _rocketMovement.ApplyMovement(f);
    }

    private void OnBoost(InputValue value)
    {
        _rocketMovement.ApplyBoost();
    }

}