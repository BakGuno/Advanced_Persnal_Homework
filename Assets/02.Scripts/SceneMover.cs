using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : SingletoneBase<SceneMover>
{
   public void OnStartBtnClick()
   {
      SceneManager.LoadScene("TutorialScene");
   }
}
