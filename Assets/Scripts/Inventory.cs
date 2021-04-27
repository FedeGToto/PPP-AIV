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

        itemNumber.text = $"x{num.ToString()}";
    }

    public void Add()
    {
        num++;
        itemNumber.text = $"x{num.ToString()}";
    }

}
