#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class GameXLuaProcedureBaseWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Game.XLuaProcedureBase);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnInit", _m_OnInit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnter", _m_OnEnter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnUpdate", _m_OnUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnLeave", _m_OnLeave);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "LuaProcedure", _g_get_LuaProcedure);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _hotfixTypeName = LuaAPI.lua_tostring(L, 2);
					
					var gen_ret = new Game.XLuaProcedureBase(_hotfixTypeName);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Game.XLuaProcedureBase constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnInit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureBase gen_to_be_invoked = (Game.XLuaProcedureBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager> _procedureOwner = (GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>)translator.GetObject(L, 2, typeof(GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>));
                    
                    gen_to_be_invoked.OnInit( _procedureOwner );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureBase gen_to_be_invoked = (Game.XLuaProcedureBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager> _procedureOwner = (GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>)translator.GetObject(L, 2, typeof(GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>));
                    
                    gen_to_be_invoked.OnEnter( _procedureOwner );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnUpdate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureBase gen_to_be_invoked = (Game.XLuaProcedureBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager> _procedureOwner = (GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>)translator.GetObject(L, 2, typeof(GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>));
                    float _elapseSeconds = (float)LuaAPI.lua_tonumber(L, 3);
                    float _realElapseSeconds = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.OnUpdate( _procedureOwner, _elapseSeconds, _realElapseSeconds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnLeave(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureBase gen_to_be_invoked = (Game.XLuaProcedureBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager> _procedureOwner = (GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>)translator.GetObject(L, 2, typeof(GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>));
                    bool _isShutdown = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.OnLeave( _procedureOwner, _isShutdown );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureBase gen_to_be_invoked = (Game.XLuaProcedureBase)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager> _procedureOwner = (GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>)translator.GetObject(L, 2, typeof(GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>));
                    
                    gen_to_be_invoked.OnDestroy( _procedureOwner );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LuaProcedure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Game.XLuaProcedureBase gen_to_be_invoked = (Game.XLuaProcedureBase)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.LuaProcedure);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
