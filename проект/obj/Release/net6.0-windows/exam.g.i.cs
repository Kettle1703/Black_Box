﻿#pragma checksum "..\..\..\exam.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD2A11EB97C83CE44F93C3E40DFAFE559F3B962E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using проект;


namespace проект {
    
    
    /// <summary>
    /// exam
    /// </summary>
    public partial class exam : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\..\exam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock exam_on;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\exam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock number_of_test;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\exam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock test;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\exam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox input_exam;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\exam.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock info;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/проект;component/exam.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\exam.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 27 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExamBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 41 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Go_to_algorihm);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 54 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Calculator_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.exam_on = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.number_of_test = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.test = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.input_exam = ((System.Windows.Controls.TextBox)(target));
            
            #line 125 "..\..\..\exam.xaml"
            this.input_exam.KeyUp += new System.Windows.Input.KeyEventHandler(this.input_exam_KeyUp);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 139 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Last_test);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 152 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Next_test);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 167 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.New_exam);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 180 "..\..\..\exam.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Make_solution);
            
            #line default
            #line hidden
            return;
            case 12:
            this.info = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

