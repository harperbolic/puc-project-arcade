using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] hpImages;

    public void RemoveHeart() 
    {
        for (int i = 0; i < hpImages.Length; i++)
        {
            GameObject heartToCheck = hpImages[hpImages.Length - i - 1];
            if (heartToCheck.activeSelf)
            {
                heartToCheck.SetActive(false);
                break;
            }
        }
    }

    public void AddHeart(bool fullHealth)
    {
        foreach (var heart in hpImages)
        {
            if (!heart.activeSelf)
            {
                heart.SetActive(true);
                if (!fullHealth)
                {
                    break;
                }
            }
        }
    }
}
