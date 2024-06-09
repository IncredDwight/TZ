using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _health.OnTakenDamage += Display;
    }

    private void Display(float health)
    {
        _image.fillAmount = health;
    }
}
