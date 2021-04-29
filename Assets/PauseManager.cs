using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PlayerInputs player;
    bool isPause;

    public void OnPointerClick(PointerEventData eventData)
    {
        isPause = !isPause;
        player.SetPause(isPause);
    }
}
