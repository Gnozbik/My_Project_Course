﻿#pragma checksum "..\..\..\Pages\Capcha.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "764C9CA8CB772082885CC25350FCA446B166561FDDD86ACD4DAD33472CF32FC2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Laboratoria.Pages;
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


namespace Laboratoria.Pages {
    
    
    /// <summary>
    /// Capcha
    /// </summary>
    public partial class Capcha : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Pages\Capcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_back;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\Capcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_send;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\Capcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox enter_textBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\Capcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox capcha_Tb;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\Capcha.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_new;
        
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
            System.Uri resourceLocater = new System.Uri("/Laboratoria;component/pages/capcha.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Capcha.xaml"
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
            
            #line 11 "..\..\..\Pages\Capcha.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Bt_back = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Pages\Capcha.xaml"
            this.Bt_back.Click += new System.Windows.RoutedEventHandler(this.Bt_back_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Bt_send = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Pages\Capcha.xaml"
            this.Bt_send.Click += new System.Windows.RoutedEventHandler(this.Bt_send_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.enter_textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.capcha_Tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Bt_new = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\Capcha.xaml"
            this.Bt_new.Click += new System.Windows.RoutedEventHandler(this.Bt_new_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
