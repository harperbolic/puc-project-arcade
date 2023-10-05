using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Negacao : MonoBehaviour
{
    public Slider slider;
    public float maxFuel = 100f; // O valor m�ximo da barra de combust�vel
    public float fuelDecreaseRate = 1f; // Taxa de decr�scimo do combust�vel por segundo
    public float fuelIncreaseAmount = 20f; // Quantidade de combust�vel adicionada ao pegar um item

    public float currentFuel;

    private void Start()
    {
        currentFuel = maxFuel;
        slider.maxValue = maxFuel;
        slider.value = currentFuel;
    }

    private void Update()
    {
        // Reduz o combust�vel com o tempo
        currentFuel -= fuelDecreaseRate * Time.deltaTime;

        // Atualiza a barra de combust�vel
        slider.value = currentFuel;

        // Verifica se o combust�vel acabou
        if (currentFuel <= 0)
        {
            // Implemente a l�gica para o fim do jogo aqui
            // Por exemplo, voc� pode carregar uma cena de "Game Over"
        }
    }

    // M�todo para adicionar combust�vel ao pegar um item
    public void AddFuel(float amount)
    {
        currentFuel = Mathf.Min(currentFuel + amount, maxFuel);
        slider.value = currentFuel;
    }
}
