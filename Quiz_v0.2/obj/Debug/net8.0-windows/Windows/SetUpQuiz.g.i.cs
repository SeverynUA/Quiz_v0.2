﻿#pragma checksum "..\..\..\..\Windows\SetUpQuiz.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7345C5D302ABACA773E09C014152172C403D0482"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz_v0._1.Windows;
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


namespace Quiz_v0._1.Windows {
    
    
    /// <summary>
    /// SetUpQuiz
    /// </summary>
    public partial class SetUpQuiz : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ScrollBar scrollBar_teamCount;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock_teamCount;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_withTimer;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_secondsTimer;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_countPoints;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_startPoint;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button input_button;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_createTemplate;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Windows\SetUpQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ActiveTemplateTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Windows\SetUpQuiz.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Quiz_v0.2;component/windows/setupquiz.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\SetUpQuiz.xaml"
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
            
            #line 27 "..\..\..\..\Windows\SetUpQuiz.xaml"
            this.scrollBar_teamCount.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.scrollBar_teamCount_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBlock_teamCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.checkBox_withTimer = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\..\..\Windows\SetUpQuiz.xaml"
            this.checkBox_withTimer.Checked += new System.Windows.RoutedEventHandler(this.checkBox_withTimer_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBox_secondsTimer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.checkBox_countPoints = ((System.Windows.Controls.CheckBox)(target));
            
            #line 43 "..\..\..\..\Windows\SetUpQuiz.xaml"
            this.checkBox_countPoints.Checked += new System.Windows.RoutedEventHandler(this.checkBox_countPoints_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBox_startPoint = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.input_button = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\Windows\SetUpQuiz.xaml"
            this.input_button.Click += new System.Windows.RoutedEventHandler(this.input_button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.button_createTemplate = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\Windows\SetUpQuiz.xaml"
            this.button_createTemplate.Click += new System.Windows.RoutedEventHandler(this.button_createTemplate_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ActiveTemplateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.createGameButton = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Windows\SetUpQuiz.xaml"
            this.createGameButton.Click += new System.Windows.RoutedEventHandler(this.createGameButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

