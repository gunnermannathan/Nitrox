﻿using AssetsTools.NET;
using UWE;

namespace NitroxServer_Subnautica.Serialization.Resources.Parsers.Monobehaviours
{
    class WorldEntityDataParser : AssetParser
    {
        public override void Parse(AssetIdentifier gameObjectIdentifier, AssetsFileReader reader, ResourceAssets resourceAssets)
        {
            reader.Align();
            uint size = reader.ReadUInt32();
            WorldEntityInfo wei;

            for (int i = 0; i < size; i++)
            {
                wei = new WorldEntityInfo();
                wei.classId = reader.ReadCountStringInt32();
                wei.techType = (TechType)reader.ReadInt32();
                wei.slotType = (EntitySlot.Type)reader.ReadInt32();
                wei.prefabZUp = reader.ReadBoolean();

                reader.Align();

                wei.cellLevel = (LargeWorldEntity.CellLevel)reader.ReadInt32();
                wei.localScale = new UnityEngine.Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                resourceAssets.WorldEntitiesByClassId.Add(wei.classId, wei);
            }
        }
    }
}
