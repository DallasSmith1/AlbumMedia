﻿#pragma checksum "..\..\MoviePlayer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "10A10A9A43B12E1AF66B3468BA705D6616582121DC68ABFA3E1FFB2950074D41"
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
using MahApps.Metro.Controls;
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
    /// MoviePlayer
    /// </summary>
    public partial class MoviePlayer : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AlbumMedia.MoviePlayer MoviePlayer1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mdeMoviePlayer;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sdrMovieProgess;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack30;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnForward30;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPause;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMovieTitle;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalTime;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCurrentTime;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSound;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sdrVolume;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MoviePlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFullscreen;
        
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
            System.Uri resourceLocater = new System.Uri("/AlbumMedia;component/movieplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MoviePlayer.xaml"
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
            this.MoviePlayer1 = ((AlbumMedia.MoviePlayer)(target));
            
            #line 9 "..\..\MoviePlayer.xaml"
            this.MoviePlayer1.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Hover);
            
            #line default
            #line hidden
            
            #line 9 "..\..\MoviePlayer.xaml"
            this.MoviePlayer1.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Leave);
            
            #line default
            #line hidden
            
            #line 9 "..\..\MoviePlayer.xaml"
            this.MoviePlayer1.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.MovieClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mdeMoviePlayer = ((System.Windows.Controls.MediaElement)(target));
            
            #line 16 "..\..\MoviePlayer.xaml"
            this.mdeMoviePlayer.MediaOpened += new System.Windows.RoutedEventHandler(this.Opened);
            
            #line default
            #line hidden
            return;
            case 3:
            this.sdrMovieProgess = ((System.Windows.Controls.Slider)(target));
            
            #line 17 "..\..\MoviePlayer.xaml"
            this.sdrMovieProgess.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.MovieTimeChange);
            
            #line default
            #line hidden
            
            #line 17 "..\..\MoviePlayer.xaml"
            this.sdrMovieProgess.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Mouse_Down);
            
            #line default
            #line hidden
            
            #line 17 "..\..\MoviePlayer.xaml"
            this.sdrMovieProgess.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Mouse_Up);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnBack30 = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\MoviePlayer.xaml"
            this.btnBack30.Click += new System.Windows.RoutedEventHandler(this.btnBack30_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnForward30 = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\MoviePlayer.xaml"
            this.btnForward30.Click += new System.Windows.RoutedEventHandler(this.btnForward30_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPause = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MoviePlayer.xaml"
            this.btnPause.Click += new System.Windows.RoutedEventHandler(this.btnPause_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MoviePlayer.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblMovieTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblTotalTime = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblCurrentTime = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.btnSound = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\MoviePlayer.xaml"
            this.btnSound.Click += new System.Windows.RoutedEventHandler(this.btnSound_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.sdrVolume = ((System.Windows.Controls.Slider)(target));
            
            #line 34 "..\..\MoviePlayer.xaml"
            this.sdrVolume.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.VolumeChange);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnFullscreen = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\MoviePlayer.xaml"
            this.btnFullscreen.Click += new System.Windows.RoutedEventHandler(this.btnFullscreen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
