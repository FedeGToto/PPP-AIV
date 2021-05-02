using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [SerializeField] PlayerInputs[] player;
    [SerializeField] int costForPause;
    bool isPause;
    bool[] scenePaused;

    private void Start()
    {
        scenePaused = new bool[player.Length];
    }

    public void PauseOneScene()
    {
        if (Inventory.instance.num >= costForPause)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (!scenePaused[i])
                {
                    scenePaused[i] = true;
                    player[i].SetPause();
                    Inventory.instance.Remove(costForPause);
                    return;
                }
            }
        }
    }
}
