using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField] TextMeshProUGUI itemNumber;
    public int num { get; protected set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        //PlayerInputs eventItem = GameObject.Find("Player").GetComponent<PlayerInputs>();

        GameObject g = GameObject.FindGameObjectWithTag("Player");
        PlayerInputs eventItem = g.GetComponent<PlayerInputs>();
        eventItem.resetItems += ResetScore;

        itemNumber.text = $"x{num.ToString()}";
    }

    public void Add()
    {
        num++;
        itemNumber.text = $"x{num.ToString()}";
    }

    public bool Remove(int cost)
    {
        if (cost <= num){
            num -= cost;
            itemNumber.text = $"x{num.ToString()}";
            return true;
        }
        return false;
    }

    private void ResetScore(object sender, EventArgs e)
    {
        num = 0;
        itemNumber.text = $"x{num.ToString()}";
    }

}
