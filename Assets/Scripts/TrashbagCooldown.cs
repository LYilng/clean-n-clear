using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashbagCooldown : MonoBehaviour
{
    public Slider cooldownSlider;
    public Gradient gradient;
    public Image fill;

    public void StartCooldown()
    {
        StartCoroutine(CooldownCoroutine());
    }

    public IEnumerator CooldownCoroutine()
    {
        float cooldownDuration = cooldownSlider.maxValue;

        float elapsedTime = 0f;

        while (elapsedTime < cooldownDuration)
        {
            elapsedTime += Time.deltaTime;
            cooldownSlider.value = cooldownDuration - elapsedTime;
            fill.color = gradient.Evaluate(cooldownSlider.normalizedValue);
            yield return null;
        }

        //cooldownSlider.gameObject.SetActive(false);
        cooldownSlider.value = cooldownSlider.maxValue;
    }
}
