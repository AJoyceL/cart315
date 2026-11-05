using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAudio : MonoBehaviour
{
  public AudioSource footsteps;

  void Update()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed || Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed || Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed || Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                footsteps.enabled = true;
            }
        else
        {
            footsteps.enabled = false;
        }
    }
}
