using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;

    public CharacterData characterData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("EXTRA " + this + " DELETED");
            Destroy(gameObject);
        }
    }


    public static CharacterData GetData()
    {
        if (instance && instance.characterData)
            return instance.characterData;
        else
        {

#if UNITY_EDITOR
            CharacterData[] characters = GetAllCharacterDataAssets();
            if (characters.Length > 0)
            {
                Debug.Log("No CharacterSelector instance found, selecting random character");
                return characters[0]; 
            }
#endif
        }
        return null;
    }

    public static CharacterData[] GetAllCharacterDataAssets()
    {
        List<CharacterData> characters = new List<CharacterData>();

#if UNITY_EDITOR
        string[] guids = AssetDatabase.FindAssets("t:CharacterData", new[] { "Assets" });
        if (guids.Length > 0)
        {
            string randomGuid = guids[Random.Range(0, guids.Length)];
            string assetPath = AssetDatabase.GUIDToAssetPath(randomGuid);
            CharacterData randomCharacter = AssetDatabase.LoadAssetAtPath<CharacterData>(assetPath);
            return new CharacterData[] { randomCharacter };
        }
#endif

        return characters.ToArray();
    }

    public void SelectCharacter(CharacterData character)
    {
        characterData = character;
    }

    // Destroys the character selector.
    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}