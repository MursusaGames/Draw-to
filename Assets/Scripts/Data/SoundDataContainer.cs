using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SoundDataContainer")]
public class SoundDataContainer : ScriptableObject
{
    public List<SoundData> sounds;
}
