﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _4IHandlerForLanguageChange.Resource {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MyLanguage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MyLanguage() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("_4IHandlerForLanguageChange.Resource.MyLanguage", typeof(MyLanguage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 中文 的本地化字符串。
        /// </summary>
        internal static string 中文 {
            get {
                return ResourceManager.GetString("中文", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 你好啊 的本地化字符串。
        /// </summary>
        internal static string 你好 {
            get {
                return ResourceManager.GetString("你好", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 WPF多语言示例 的本地化字符串。
        /// </summary>
        internal static string 文本 {
            get {
                return ResourceManager.GetString("文本", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 加载...... 的本地化字符串。
        /// </summary>
        internal static string 文本2 {
            get {
                return ResourceManager.GetString("文本2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 英文 的本地化字符串。
        /// </summary>
        internal static string 英文 {
            get {
                return ResourceManager.GetString("英文", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 语言 的本地化字符串。
        /// </summary>
        internal static string 语言 {
            get {
                return ResourceManager.GetString("语言", resourceCulture);
            }
        }
    }
}
