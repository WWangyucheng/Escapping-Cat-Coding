using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchColor : MonoBehaviour
{
    public ComponentType componentType;
    public Color startColor;
    public Color endColor;

    public void SwitchObjColor()
    {
        switch(componentType)
        {
            case ComponentType.player:
                {
                    //这种写法是if语句的缩写写法，就是判断SpriteRenderer若为startColor 则转化为endColor，反之亦然   
                    GetComponentInChildren<SpriteRenderer>().color = GetComponentInChildren<SpriteRenderer>().color == startColor ? endColor : startColor;
                    break;

                }
            case ComponentType.spriteRender :
                {
                    GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color == startColor ? endColor : startColor;
                    break;
                }
            case ComponentType.image :
                {
                    GetComponent<Image >().color = GetComponent<Image >().color == startColor ? endColor : startColor;
                    break;
                }
            case ComponentType.text:
                {
                    GetComponent<Text >().color = GetComponent<Text >().color == startColor ? endColor : startColor;
                    break;
                }
            case ComponentType.camera :
                {
                    Camera .main.backgroundColor = Camera.main.backgroundColor== startColor ? endColor : startColor;
                    break;
                }
            case ComponentType.ground:
                {
                    //是地面存在和地面不存在之间的切换
                    GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
                    GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color == startColor ? endColor : startColor;
                   
                    break;

                }
        }

    }
}

public enum ComponentType
{
player,spriteRender,image,text,camera,ground
}

