using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class System_Game : MonoBehaviour
{
  public static System_Game instance;
  public int countEnemies;
  public GameObject[] ArPlayer;
  public int indexPlayer;
  [SerializeField] GameObject[] enemies;
private void Start() {
  instance=this;
  DontDestroyOnLoad(transform.gameObject);

}
  void FixedUpdate()
  {
    ArPlayer = GameObject.FindGameObjectsWithTag("Player");
    enemies = GameObject.FindGameObjectsWithTag("enemies");
    countEnemies=enemies.Length;
   
    
  }
 
   public void cc(){
    SceneManager.LoadScene("SampleScene");
   }
}
