using System.Collections.Generic;
using GameFramework;
using GameFramework.Fsm;
using GameFramework.Procedure;
using GameFramework.Resource;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Game
{
    public class ProcedureCodeInit : ProcedureBase
    {
        private Dictionary<string, bool> m_LoadedFlag;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Resource.LoadAsset(AssetUtility.GetConfigAsset("LuaScriptCollection", false), new LoadAssetCallbacks(OnConfigLoadedSuccess, OnAssetLoadedFail));
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            m_LoadedFlag = null;

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (m_LoadedFlag == null)
            {
                return;
            }

            foreach (KeyValuePair<string, bool> loadedFlag in m_LoadedFlag)
            {
                if (!loadedFlag.Value)
                {
                    return;
                }
            }

            ChangeState<ProcedurePreload>(procedureOwner);
        }

        private void OnConfigLoadedSuccess(string assetName, object asset, float duration, object userdata)
        {
            TextAsset config = (TextAsset)asset;
            Debug.Log(config.text);
            List<string> luaScriptNames = Utility.Json.ToObject<List<string>>(config.text);
            LoadAssetCallbacks callbacks = new LoadAssetCallbacks(OnLuaScriptsLoadedSuccess, OnAssetLoadedFail);
            m_LoadedFlag = new Dictionary<string, bool>();
            foreach (string luaScriptName in luaScriptNames)
            {
                Debug.Log(luaScriptName);
                m_LoadedFlag.Add(luaScriptName, false);
                GameEntry.Resource.LoadAsset(AssetUtility.GetLuaScriptAsset(luaScriptName), callbacks, luaScriptName);
            }
            Log.Info("Load '{0}' OK.", assetName);
        }

        private void OnLuaScriptsLoadedSuccess(string assetName, object asset, float duration, object userdata)
        {
            string luaScriptName = userdata.ToString();
            TextAsset luaScripts = (TextAsset)asset;
            GameEntry.XLua.CacheLuaScripts(luaScriptName, luaScripts.text);
            m_LoadedFlag[luaScriptName] = true;
            Log.Info("Load Lua Script '{0}' OK.", assetName);
        }

        private void OnAssetLoadedFail(string assetName, LoadResourceStatus status, string errorMessage, object userdata)
        {
            Log.Error("Can not load '{0}' with error message '{1}'.", assetName, errorMessage);
        }
    }
}
