﻿#pragma checksum "..\..\FullScreen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7B39DC12FA3D1B8B065115F30BA28DF5BEFAF378E4596AEFE69C056C5AA7D2C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AlbumMedia;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace AlbumMedia {
    
    
    /// <summary>
    /// FullScreen
    /// </summary>
    public partial class FullScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\FullScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AlbumMedia.FullScreen window;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\FullScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frmMain;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AlbumMedia;component/fullscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FullScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((AlbumMedia.FullScreen)(target));
            
            #line 8 "..\..\FullScreen.xaml"
            this.window.Closed += new System.EventHandler(this.HasClosed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\FullScreen.xaml"
            this.window.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Mouse_LEave);
            
            #line default
            #line hidden
            
            #line 8 "..\..\FullScreen.xaml"
            this.window.MouseMove += new System.Windows.Input.MouseEventHandler(this.Mouse_Enter);
            
            #line default
            #line hidden
            
            #line 8 "..\..\FullScreen.xaml"
            this.window.KeyDown += new System.Windows.Input.KeyEventHandler(this.KeyDown_Pressed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.frmMain = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

