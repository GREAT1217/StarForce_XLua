// using UnityEngine;
// using UnityGameFramework.Runtime;
//
// namespace Game.Hotfix
// {
//     public abstract class HotfixTargetableObject
//     {
//         protected TargetableObjectData TargetableObjectData
//         {
//             get;
//             private set;
//         }
//
//         /// <summary>
//         /// 底层实体逻辑。
//         /// </summary>
//         public ILTargetableObject ILTargetableObject
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
//                 Log.Error("ILTargetableObject data is invalid.");
//                 return;
//             }
//
//             ILTargetableObject = data.BaseLogic as ILTargetableObject;
//             TargetableObjectData = data.UserData as TargetableObjectData;
//         }
//
//         /// <summary>
//         /// 实体显示。
//         /// </summary>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnShow(object userData)
//         {
//             if (TargetableObjectData == null)
//             {
//                 Log.Error("ILTargetableObject userData is invalid.");
//                 return;
//             }
//
//             ILTargetableObject.CachedTransform.position = TargetableObjectData.Position;
//             ILTargetableObject.CachedTransform.rotation = TargetableObjectData.Rotation;
//         }
//
//         /// <summary>
//         /// 实体隐藏。
//         /// </summary>
//         /// <param name="isShutdown">是否是关闭状态机时触发。</param>
//         /// <param name="userData">用户自定义数据。</param>
//         public virtual void OnHide(bool isShutdown, object userData)
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
//         public virtual void OnTriggerEnter(Collider other)
//         {
//         }
//
//         /// <summary>
//         /// 触发器离开的回调。
//         /// </summary>
//         /// <param name="other"></param>
//         public virtual void OnTriggerExit(Collider other)
//         {
//         }
//
//         public virtual void OnDead(Entity attacker)
//         {
//         }
//
//         public abstract ImpactData GetImpactData();
//     }
// }
