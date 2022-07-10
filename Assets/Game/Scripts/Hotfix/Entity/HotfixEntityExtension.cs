// using GameFramework.DataTable;
// using System;
// using UnityGameFramework.Runtime;
//
// namespace Game.Hotfix
// {
//     public static class HotfixEntityExtension
//     {
//         public static void ShowHotfixMyAircraft(this EntityComponent entityComponent, MyAircraftData data)
//         {
//             entityComponent.ShowEntity(typeof(MyAircraft), "Aircraft", Constant.AssetPriority.MyAircraftAsset, data);
//         }
//
//         public static void ShowHotfixAircraft(this EntityComponent entityComponent, Type logicType, AircraftData data)
//         {
//             entityComponent.ShowHotfixTargetableObject(logicType, "Aircraft", Constant.AssetPriority.AircraftAsset, data);
//         }
//         
//         public static void ShowHotfixTargetableObject(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
//         {
//             if (data == null)
//             {
//                 Log.Warning("Data is invalid.");
//                 return;
//             }
//
//             IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
//             DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
//             if (drEntity == null)
//             {
//                 Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
//                 return;
//             }
//
//             ILUserData userData = new ILUserData(logicType.ToString(), data);
//             entityComponent.ShowEntity(data.Id, typeof(ILTargetableObject), AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, userData);
//         }
//
//         public static void ShowHotfixEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
//         {
//             if (data == null)
//             {
//                 Log.Warning("Data is invalid.");
//                 return;
//             }
//
//             IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
//             DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
//             if (drEntity == null)
//             {
//                 Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
//                 return;
//             }
//
//             ILUserData userData = new ILUserData(logicType.ToString(), data);
//             entityComponent.ShowEntity(data.Id, typeof(ILEntity), AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, priority, userData);
//         }
//     }
// }
