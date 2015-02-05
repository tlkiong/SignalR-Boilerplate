﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignalR.BE {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LogMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LogMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SignalR.BE.LogMessage", typeof(LogMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br/&gt;{0} client connected to Hub&lt;br/&gt;ConnectionID: {1}&lt;br/&gt;Status: Connected.
        /// </summary>
        public static string ConnectedMessage {
            get {
                return ResourceManager.GetString("ConnectedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br/&gt;{0} client disconnected from Hub &lt;br/&gt;ConnectionID: {1}&lt;br/&gt;Status: Disconnected.
        /// </summary>
        public static string DisconnectedMessage {
            get {
                return ResourceManager.GetString("DisconnectedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Faill to connect to Hub exception.
        /// </summary>
        public static string ExceptionHubConnectionFail {
            get {
                return ResourceManager.GetString("ExceptionHubConnectionFail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resume connection to Hub exception.
        /// </summary>
        public static string ExceptionHubConnectionResume {
            get {
                return ResourceManager.GetString("ExceptionHubConnectionResume", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exception caught &lt;br/&gt;Message: {0}&lt;br/&gt;Inner Message: {1}&lt;br/&gt;Method: [2}.
        /// </summary>
        public static string ExceptionMessage {
            get {
                return ResourceManager.GetString("ExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br/&gt;{0} client reconnected from Hub &lt;br/&gt;ConnectionID: {1}&lt;br/&gt;Status: Reconnected.
        /// </summary>
        public static string ReconnectedMessage {
            get {
                return ResourceManager.GetString("ReconnectedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br/&gt;{0} client executed &apos;RunMethod&apos;&lt;br/&gt;ConnectionID: {1} &lt;br/&gt;Service: {2}&lt;br/&gt; Action: {3}.
        /// </summary>
        public static string RunMethodMessage {
            get {
                return ResourceManager.GetString("RunMethodMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br/&gt;{0} client subscribed to service&lt;br/&gt;ConnectionID: {1}&lt;br/&gt;Service: {2}.
        /// </summary>
        public static string SubscribeServiceMessage {
            get {
                return ResourceManager.GetString("SubscribeServiceMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown Client Connected&lt;br/&gt;ConnectionID: {0}.
        /// </summary>
        public static string UnknownClientMessage {
            get {
                return ResourceManager.GetString("UnknownClientMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;br/&gt;{0} client unsubscribe to service&lt;br/&gt;ConnectionID: {1}&lt;br/&gt;Service: {2}.
        /// </summary>
        public static string UnsubscribeServiceMessage {
            get {
                return ResourceManager.GetString("UnsubscribeServiceMessage", resourceCulture);
            }
        }
    }
}