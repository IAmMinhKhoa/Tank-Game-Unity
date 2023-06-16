using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class System_Game : MonoBehaviour
{
  public TMP_Text textCount;
  [SerializeField] protected int countEnemies;
  [SerializeField] GameObject ScreenOver;
  [SerializeField] GameObject[] ArPlayer;
  [SerializeField] GameObject[] enemies;
private void Start() {
  if(textCount==null)
  {
    Debug.Log("Error Find");
  }
}
  void FixedUpdate()
  {
    PlayerDie();
    enemies = GameObject.FindGameObjectsWithTag("enemies");
    countEnemies=enemies.Length;
    textCount.text=countEnemies.ToString();
  }
  protected void PlayerDie(){
    ArPlayer = GameObject.FindGameObjectsWithTag("Player");
    if(ArPlayer.Count()==0){

        ScreenOver.SetActive(true);
    }
  }
   
}
