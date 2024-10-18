using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private Image fillBar;
    private void Start()
    {
        fillBar.fillAmount = 1;
    }

    private void Update()
    {
        fillBar.fillAmount = energySystem.Fuel / energySystem.MaxFuel;
    }

}