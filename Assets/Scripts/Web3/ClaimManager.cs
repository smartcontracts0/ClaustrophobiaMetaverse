using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI; // Add this line to include the UI namespace
using Thirdweb;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
//using UnityEditor.Build.Content;

public class ClaimManager : MonoBehaviour
{
    public GameObject returnBtn;
    public GameObject claimBtn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async Task ClaimNFT()
    {
        Contract contract = SDKManager.Instance.SDK.GetContract("0xD604BCd47EC739367aa6f08D8A516764c8CBc8C1");
        await contract.ERC721.Claim(1);
    }

    public async void Claim()
    {
        await ClaimNFT();
        claimBtn.SetActive(false);
        returnBtn.SetActive(true);
    }



    public void ReturntoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
