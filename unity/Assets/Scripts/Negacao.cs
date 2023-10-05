using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Negacao : MonoBehaviour
{
    public Slider slider;
    public float maxFuel = 100f; // O valor máximo da barra de combustível
    public float fuelDecreaseRate = 1f; // Taxa de decréscimo do combustível por segundo
    public float fuelIncreaseAmount = 20f; // Quantidade de combustível adicionada ao pegar um item

    public float currentFuel;

    private void Start()
    {
        currentFuel = maxFuel;
        slider.maxValue = maxFuel;
        slider.value = currentFuel;
    }

    private void Update()
    {
        // Reduz o combustível com o tempo
        currentFuel -= fuelDecreaseRate * Time.deltaTime;

        // Atualiza a barra de combustível
        slider.value = currentFuel;

        // Verifica se o combustível acabou
        if (currentFuel <= 0)
        {
            // Implemente a lógica para o fim do jogo aqui
            // Por exemplo, você pode carregar uma cena de "Game Over"
        }
    }

    // Método para adicionar combustível ao pegar um item
    public void AddFuel(float amount)
    {
        currentFuel = Mathf.Min(currentFuel + amount, maxFuel);
        slider.value = currentFuel;
    }
}
