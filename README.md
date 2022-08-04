## 简介

使用 XLua 对 StarForce 实现 UI 逻辑热更新。使用的最基础的 lua 语法实现的面向对象。

### UI 热更实现逻辑

> 热更层 LuaForm 使用 XLuaUserData 和底层 XLuaForm 进行逻辑绑定，XLuaForm 逻辑继承自框架的 UIForm，内部初始化热更新层 LuaForm，并记录引用，可以实现使用 UI 模块使用 GameEntry.UI 操作热更新层的 LuaForm。LuaForm 内部记录记录了底层 XLuaForm 的引用，可以通过组件集合 ComponentCollection 访问 UI 组件。

### 使用步骤

1. 增加或删除 lua 文件后，通过菜单 "Game / Generate XLua Collection"，收集并生成 lua 脚本集合文件，用于启动时加载。
2. 在 XLuaConfig.cs 脚本中编辑白名单和黑名单的静态列表，用于指定生成、不生成哪些代码。不需要也不建议使用打标签的方式。通过菜单 "XLua / Generate Code"，生成代码解释器和桥接委托。

## 相关链接

**GameFramework** - [https://gameframework.cn/](https://gameframework.cn/)

**XLua** - [https://tencent.github.io/xLua/public/v1/guide/index.html](https://tencent.github.io/xLua/public/v1/guide/index.html)