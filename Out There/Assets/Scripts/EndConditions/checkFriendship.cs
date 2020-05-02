using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkFriendship : MonoBehaviour
{
    public NPC aman;
    public NPC arthur;
    public NPC ashley;
    public NPC corran;
    public NPC marina;
    public NPC merchant;
    public NPC rinya;

    public int winWhenFriendshipIs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( aman.friendship >= winWhenFriendshipIs &&
            arthur.friendship >= winWhenFriendshipIs &&
            ashley.friendship >= winWhenFriendshipIs &&
            corran.friendship >= winWhenFriendshipIs &&
            marina.friendship >= winWhenFriendshipIs &&
            merchant.friendship >= winWhenFriendshipIs &&
            rinya.friendship >= winWhenFriendshipIs) {
                SceneManager.LoadScene("EndScene");
            }
    }
}
