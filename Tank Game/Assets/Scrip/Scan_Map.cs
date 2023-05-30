using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan_Map : MonoBehaviour
{
    // Start is called before the first frame update
    public AstarPath astarPath;
    public float time_scan = 0.2f;
    void Start()
    {
        StartCoroutine(ScanMapCoroutine());
    }

    private IEnumerator ScanMapCoroutine()
    {
        while (true)
        {
            astarPath.Scan();
            yield return new WaitForSeconds(time_scan);
        }
    }
}
