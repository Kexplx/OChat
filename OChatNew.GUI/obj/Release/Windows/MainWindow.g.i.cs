﻿#pragma checksum "..\..\..\Windows\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57B5A3EEE9E7E53A410BC0B1F9D10E108134CCD4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace OChatNew.GUI {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DtGrdOnlineUsers;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Brd1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox MainChatBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Brd1_Copy;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBoxEnter;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogOut;
        
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
            System.Uri resourceLocater = new System.Uri("/OChatNew.GUI;component/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\MainWindow.xaml"
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
            
            #line 5 "..\..\..\Windows\MainWindow.xaml"
            ((OChatNew.GUI.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DtGrdOnlineUsers = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.Brd1 = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.MainChatBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.Brd1_Copy = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.TxtBoxEnter = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\Windows\MainWindow.xaml"
            this.TxtBoxEnter.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Windows\MainWindow.xaml"
            this.BtnLogOut.Click += new System.Windows.RoutedEventHandler(this.BtnLogOut_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

