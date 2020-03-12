using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainSceneAvatarChanger : MonoBehaviour
{
    // Start is called before the first frame update
    Sprite avatarSprite;
    public Image avatarImage;
    public Sprite[] possibleSprites = new Sprite[6]; //0 = WF | 1 = BF | 2 = AF | 3 = WM | 4 = BM | 5 = AM
    public SpriteRenderer spriteRenderer;
    GameObject avatarHolder;
    CharacterAvatar avatar;
    void Start()
    {
        avatarHolder = GameObject.FindGameObjectWithTag("Avatar_Holder");
        avatar = avatarHolder.GetComponent<CharacterAvatar>();

        if(avatar.gender == 0) //female
        {
            switch (avatar.race)
            {
                case 0: //white
                    avatarSprite = possibleSprites[0];
                    avatarImage.sprite = avatarSprite;
                    //spriteRenderer.sprite = avatarSprite;
                    break;

                case 1: //black
                    avatarSprite = possibleSprites[1];
                    avatarImage.sprite = avatarSprite;
                    //spriteRenderer.sprite = avatarSprite;
                    break;

                case 2: //asian
                    avatarSprite = possibleSprites[2];
                    avatarImage.sprite = avatarSprite;
                    //spriteRenderer.sprite = avatarSprite;
                    break;

            }

        }
        else //male
        {
            switch (avatar.race)
            {
                case 0: //white
                    avatarSprite = possibleSprites[3];
                    avatarImage.sprite = avatarSprite;
                    //spriteRenderer.sprite = avatarSprite;
                    break;

                case 1: //black
                    avatarSprite = possibleSprites[4];
                    avatarImage.sprite = avatarSprite;
                    //spriteRenderer.sprite = avatarSprite;

                    break;

                case 2: //asian
                    avatarSprite = possibleSprites[5];
                    avatarImage.sprite = avatarSprite;
                    //spriteRenderer.sprite = avatarSprite;
                    break;

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
