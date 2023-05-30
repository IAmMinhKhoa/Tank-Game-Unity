using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{
    static public Effect_Manager instance;
    public List<GameObject> effects;
    private Dictionary<string, Transform> spawnObjectParents = new Dictionary<string, Transform>();
    private void Awake()
    {
        instance = this;
        LoadEffect();
    }
    protected virtual void LoadEffect()
    {
        effects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            effects.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }
    public void SpawnVFX(string effectName, Vector3 position, Quaternion rot)
    {
        CreateObjectParentIfNeeded(effectName);

        GameObject effect = Get(effectName);
        GameObject newEffect = Instantiate(effect, position, rot, spawnObjectParents[effectName]);
        newEffect.SetActive(true);
    }
    protected GameObject Get(string effectName)
    {
        foreach (GameObject child in effects)
        {
            if (child.name == effectName) return child;
        }
        return null;
    }
    private void CreateObjectParentIfNeeded(string effectName)
    {
        // Ki?m tra xem object parent ?ã ???c t?o hay ch?a
        if (!spawnObjectParents.ContainsKey(effectName))
        {
            string name = "Parent_Effects_" + effectName;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
            {
                spawnObjectParents[effectName] = parentObject.transform;
            }
            else
            {
                Transform newParent = new GameObject(name).transform;
                spawnObjectParents[effectName] = newParent;
            }
        }
    }
}
