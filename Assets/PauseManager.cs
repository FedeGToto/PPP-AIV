using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour
{
    [SerializeField] PlayerInputs[] player;
    bool isPause;

    public void PauseOneScene()
    {
        isPause = !isPause;
        player[Random.Range(0, player.Length)].SetPause(isPause);
    }

}
