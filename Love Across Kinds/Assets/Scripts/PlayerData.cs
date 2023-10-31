using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PlayerData
{
    public int episode;
    public int episodeCount;
    public float[] position;

    public PlayerData(Player player) 
    {
        episode = player.episode;
        episodeCount = player.episodeCount;


        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
