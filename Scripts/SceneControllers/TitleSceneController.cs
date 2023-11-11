using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneController : SceneController
{
  protected override void Trigger()
  {
    if (Input.anyKeyDown)
    {
      this.hasTriggered = true;
    }
  }

  protected override void StartTransition()
  {
    foreach (TransitionTarget transitionTarget in this.transitionTargets)
    {
      transitionTarget.GetComponent<Animator>().Play("Transition");
    }
  }

  protected override void CompleteTransition()
  {
    Initiate.Fade(this.nextSceneName, Color.black, 1.5f);
  }
}
