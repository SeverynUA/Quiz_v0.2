﻿#pragma checksum "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4A4C405EA12DC8B86A0FA21860D14BFB86466713"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz_v0._2.Windows.SetUp;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Quiz_v0._2.Windows.SetUp {
    
    
    /// <summary>
    /// SetUpQuiz
    /// </summary>
    public partial class SetUpQuiz : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ScrollBar scrollBar_teamCount;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock teamCountText;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_withTimer;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_secondsTimer;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button input_button;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createTemplateButton;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ActiveTemplateTextBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createGameButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Quiz_v0.2;V1.0.0.0;component/windows/setup/setupquiz.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.scrollBar_teamCount = ((System.Windows.Controls.Primitives.ScrollBar)(target));
            
            #line 44 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            this.scrollBar_teamCount.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.scrollBar_teamCount_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.teamCountText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.checkBox_withTimer = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            this.checkBox_withTimer.Checked += new System.Windows.RoutedEventHandler(this.checkBox_withTimer_Checked);
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            this.checkBox_withTimer.Unchecked += new System.Windows.RoutedEventHandler(this.checkBox_withTimer_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBox_secondsTimer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.input_button = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            this.input_button.Click += new System.Windows.RoutedEventHandler(this.input_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.createTemplateButton = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            this.createTemplateButton.Click += new System.Windows.RoutedEventHandler(this.createTemplateButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ActiveTemplateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.createGameButton = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\..\Windows\SetUp\SetUpQuiz.xaml"
            this.createGameButton.Click += new System.Windows.RoutedEventHandler(this.createGameButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

