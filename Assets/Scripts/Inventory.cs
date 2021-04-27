using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField] TextMeshProUGUI itemNumber;
    int num;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Add()
    {
        num++;
        itemNumber.text = num.ToString();
    }

}
