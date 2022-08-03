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
    public class GameXLuaProcedureManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Game.XLuaProcedureManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartXLuaProcedure", _m_StartXLuaProcedure);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeXLuaProcedure", _m_ChangeXLuaProcedure);
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Game.XLuaProcedureManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Game.XLuaProcedureManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartXLuaProcedure(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureManager gen_to_be_invoked = (Game.XLuaProcedureManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _hotfixTypeName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.StartXLuaProcedure( _hotfixTypeName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeXLuaProcedure(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.XLuaProcedureManager gen_to_be_invoked = (Game.XLuaProcedureManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager> _procedureOwner = (GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>)translator.GetObject(L, 2, typeof(GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>));
                    string _hotfixTypeName = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.ChangeXLuaProcedure( _procedureOwner, _hotfixTypeName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
