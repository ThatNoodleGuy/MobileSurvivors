using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats player;
    public PassiveItemScriptableObject passiveItemData;
    
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();

        ApplyModifier();
    }

    void Update()
    {
        
    }

    protected virtual void ApplyModifier()
    {

    }
}
