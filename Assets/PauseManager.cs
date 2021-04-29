using UnityEngine;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] PlayerInputs player;
    bool isPause;

    public void OnPointerClick(PointerEventData eventData)
    {
        isPause = !isPause;
        player.SetPause(isPause);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPause = !isPause;
        player.SetPause(isPause);
    }
}
