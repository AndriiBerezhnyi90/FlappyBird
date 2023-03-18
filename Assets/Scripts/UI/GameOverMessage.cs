using UnityEngine;

public class GameOverMessage : UIMessage
{
    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void Show()
    {
        gameObject.SetActive(true);
    }
}