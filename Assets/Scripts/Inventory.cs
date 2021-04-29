using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField] TextMeshProUGUI itemNumber;
    int num;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        PlayerInputs eventItem = GameObject.Find("Player").GetComponent<PlayerInputs>();
        eventItem.resetItems += ResetScore;

        itemNumber.text = $"x{num.ToString()}";
    }

    public void Add()
    {
        num++;
        itemNumber.text = $"x{num.ToString()}";
    }

    private void ResetScore(object sender, EventArgs e)
    {
        num = 0;
        itemNumber.text = $"x{num.ToString()}";
    }

}
