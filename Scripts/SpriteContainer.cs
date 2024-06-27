using System;
using APIUtility;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

public static class SpriteContainer
{
    private static Dictionary<string, Sprite> _imageDictionary = new Dictionary<string, Sprite>();
    private static Sprite _sprite;

    public static async Task<Sprite> GetSprite(string imageURL)
    {
        if (_imageDictionary.ContainsKey(imageURL))
        {
            return _imageDictionary[imageURL];
        }
        else
        {
            try
            {
                _sprite = await APIHandler.GetSprite(new SimpleRequest(imageURL));
                _imageDictionary[imageURL] = _sprite;
                Debug.Log("Sprite downloaded" + _sprite);
                return _sprite;
            }
            catch(Exception e)
            {
                Debug.LogError("Error in GetSprite in SpriteContainer : " + e + "\nURL : " + imageURL);
                return null;
            }
        }
    }

    public static async Task<Sprite> GetStoredSprite(string imageURL)
    {

        //Get a Sprite form BE and Stores it in a File, and get it when we want it
        //** This Logic is Still in Progress **\\
        if (PlayerPrefs.HasKey(imageURL))
        {
            return _imageDictionary[imageURL];
        }

        else
        {

            try
            {
                _sprite = await APIHandler.GetSprite(new SimpleRequest(imageURL));
                _imageDictionary[imageURL] = _sprite;
                Debug.Log("Sprite downloaded" + _sprite);
                return _sprite;
            }
            catch (Exception e)
            {
                Debug.LogError("Error in GetSprite in SpriteContainer : " + e + "\nURL : " + imageURL);
                return null;
            }
        }
    }
    }

