using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketControllerC : MonoBehaviour
{
    private EnergySystemC _energySystem;
    private RocketMovementC _rocketMovement;
    
    private bool _isMoving;
    private int _isBoost = 0;
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
        _isMoving = true;
    }

    private void OnBoost(InputValue value)
    {
        _isBoost++;
        if (_isBoost == 2)
        {
            if (_energySystem.UseEnergy(ENERGY_BURST))
            {
                _rocketMovement.ApplyBoost();
            }
            _isBoost = 0;
        }
    }

}