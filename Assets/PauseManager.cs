using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [SerializeField] PlayerInputs[] player;
    [SerializeField] int costForPause;
    bool isPause;

    public void PauseOneScene()
    {
        isPause = !isPause;
        int p = -1;
        do{
            p = Random.Range(0, player.Length);
        } 
        while (player[p].IsPaused());
        if (Inventory.instance.Remove(costForPause))
            player[p].SetPause();
    }
}
