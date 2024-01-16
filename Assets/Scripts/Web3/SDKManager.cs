using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;

public class SDKManager : MonoBehaviour
{
    public static SDKManager Instance;
    public ThirdwebSDK SDK;

    //This makes the SDK manager persists through out the whole game and not only the first scene
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SDK = new ThirdwebSDK("goerli"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
