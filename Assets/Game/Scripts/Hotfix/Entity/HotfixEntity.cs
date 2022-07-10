// using UnityEngine;
// using UnityGameFramework.Runtime;
//
// namespace Game.Hotfix
// {
//     public class HotfixEntity
//     {
//         /// <summary>
//         /// 实体数据。
//         /// </summary>
//         protected EntityData EntityData
//         {
//             get;
//             private set;
//         }
//
//         /// <summary>
//         /// 底层实体逻辑。
//         /// </summary>
//         protected ILEntity ILEntity
//         {
//             get;
//             private set;
//         }
//
//         /// <summary>
//         /// 实体初始化。
//         /// </summary>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnInit(object userData)
//         {
//             ILUserData data = userData as ILUserData;
//             if (data == null)
//             {
//                 Log.Error("ILEntity data is invalid.");
//                 return;
//             }
//
//             ILEntity = data.BaseLogic as ILEntity;
//             EntityData = data.UserData as EntityData;
//         }
//
//         /// <summary>
//         /// 实体显示。
//         /// </summary>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnShow(object userData)
//         {
//             if (EntityData == null)
//             {
//                 Log.Error("ILEntity userData is invalid.");
//                 return;
//             }
//             
//             ILEntity.CachedTransform.position = EntityData.Position;
//             ILEntity.CachedTransform.rotation = EntityData.Rotation;
//         }
//
//         /// <summary>
//         /// 实体隐藏。
//         /// </summary>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnHide(object userData)
//         {
//         }
//
//         /// <summary>
//         /// 实体附加子实体。
//         /// </summary>
//         /// <param name="childEntity">附加的子实体。</param>
//         /// <param name="parentTransform">被附加的父实体。</param>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
//         {
//         }
//
//         /// <summary>
//         /// 实体解除子实体。
//         /// </summary>
//         /// <param name="childEntity">解除的子实体。</param>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnDetached(EntityLogic childEntity, object userData)
//         {
//         }
//
//         /// <summary>
//         /// 实体附加子实体。
//         /// </summary>
//         /// <param name="parentEntity">被附加的父实体。</param>
//         /// <param name="parentTransform">被附加父实体的位置。</param>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
//         {
//         }
//
//         /// <summary>
//         /// 实体解除子实体。
//         /// </summary>
//         /// <param name="parentEntity">被解除的父实体。</param>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnDetachFrom(EntityLogic parentEntity, object userData)
//         {
//         }
//
//         /// <summary>
//         /// 实体轮询。
//         /// </summary>
//         /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
//         /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
//         public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
//         {
//         }
//
//         /// <summary>
//         /// 设置实体的可见性。
//         /// </summary>
//         /// <param name="visible">实体的可见性。</param>
//         public virtual void InternalSetVisible(bool visible)
//         {
//         }
//
//         /// <summary>
//         /// 触发器进入的回调。
//         /// </summary>
//         /// <param name="other"></param>
//         protected virtual void OnTriggerEnter(Collider other)
//         {
//         }
//
//         /// <summary>
//         /// 触发器离开的回调。
//         /// </summary>
//         /// <param name="other"></param>
//         protected virtual void OnTriggerExit(Collider other)
//         {
//         }
//     }
// }
