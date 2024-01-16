using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Thirdweb;
using Unity.Collections.LowLevel.Unsafe;

public class StartManager : MonoBehaviour
{
    public GameObject connected;
    public GameObject disconnected;
    public GameObject enterBtn;
    public TMPro.TextMeshProUGUI addressTxt;
    public TMPro.TextMeshProUGUI ownsNfttxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void ConnectWallet()
    {
        string address = await SDKManager.Instance.SDK.wallet.Connect(new WalletConnection() //SDKManager.Instance.SDK can be used anywhere because it is a singleton
        {
            provider = WalletProvider.Metamask,
            chainId = 5 //Goerli network ID
        });

        addressTxt.text = address;

        connected.SetActive(true);
        disconnected.SetActive(false);   

        await CheckBalance();
    }

    public async Task CheckBalance()
    {
        Contract contract = SDKManager.Instance.SDK.GetContract("0xf22271704954f8d58b7e528ac2697c8e21ae4e3b");

        string balance = await contract.ERC721.Balance();

        float balanceFloat = float.Parse(balance);

        if (balanceFloat == 0)
        {
            ownsNfttxt.text = "Sorry you cannot access the game";
            return;
        }

        ownsNfttxt.text = "Press the Enter button to access the metaverse";
        enterBtn.SetActive(true);

    }

    public void EnterGame()
    {
        SceneManager.LoadScene("Main");
    }
}
