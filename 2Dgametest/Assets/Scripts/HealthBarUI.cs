using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthFill;

    public void SetHealth(int current, int max)
    {
        float fillAmount = (float)current / max;
        healthFill.fillAmount = fillAmount;
    }
}