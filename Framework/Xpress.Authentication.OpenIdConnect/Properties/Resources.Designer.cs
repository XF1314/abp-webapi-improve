﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xpress.Authentication.OpenIdConnect.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Xpress.Authentication.OpenIdConnect.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性
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
        ///   查找类似 Cannot process the message. Both id_token and code are missing. 的本地化字符串。
        /// </summary>
        internal static string IdTokenCodeMissing {
            get {
                return ResourceManager.GetString("IdTokenCodeMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Message contains error: &apos;{0}&apos;, error_description: &apos;{1}&apos;, error_uri: &apos;{2}&apos;. 的本地化字符串。
        /// </summary>
        internal static string MessageContainsError {
            get {
                return ResourceManager.GetString("MessageContainsError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unable to unprotect the message.State. 的本地化字符串。
        /// </summary>
        internal static string MessageStateIsInvalid {
            get {
                return ResourceManager.GetString("MessageStateIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 OpenIdConnectAuthenticationHandler: message.State is null or empty. 的本地化字符串。
        /// </summary>
        internal static string MessageStateIsNullOrEmpty {
            get {
                return ResourceManager.GetString("MessageStateIsNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Unable to validate the &apos;id_token&apos;, no suitable ISecurityTokenValidator was found for: &apos;{0}&apos;.&quot; 的本地化字符串。
        /// </summary>
        internal static string UnableToValidateToken {
            get {
                return ResourceManager.GetString("UnableToValidateToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 The Validated Security Token must be of type JwtSecurityToken, but instead its type is: &apos;{0}&apos;. 的本地化字符串。
        /// </summary>
        internal static string ValidatedSecurityTokenNotJwt {
            get {
                return ResourceManager.GetString("ValidatedSecurityTokenNotJwt", resourceCulture);
            }
        }
    }
}
