using System;
using System.Collections.Generic;
using Game.LevelSystem.BallPacks;
using Game.PlatformSystem.Base;
using UnityEngine;

namespace Game.LevelSystem
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Level Datas/New Level", order = 1)]
    public class LevelData : ScriptableObject
    {
        public List<PlatformData> PlatformDatas;
        public List<BallPackData> BallPackDatas;
    }
    
    [Serializable]
    public class PlatformData
    {
        // Platforms that are not Checkpoint type's checkpoint count will be ignored.
        public Vector3 Position;
        public PlatformType PlatformType;
        public int CheckPointCount;
    }

    [Serializable]
    public class BallPackData
    {
        public Vector3 Position;
        public BallPackType BallPackType;
    }
}
