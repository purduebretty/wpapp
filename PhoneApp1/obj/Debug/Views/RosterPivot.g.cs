﻿#pragma checksum "C:\Users\Brett\Documents\GitHub\wpapp\PhoneApp1\Views\RosterPivot.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4C665C8BAB52FD1113B9303CAC476688"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using PhoneApp1.Model;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneApp1.Views {
    
    
    public partial class RosterPivot : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal PhoneApp1.Model.OffenseVisibility ShowOffense;
        
        internal PhoneApp1.Model.BenchColor DisableBenchColor;
        
        internal PhoneApp1.Model.StatConverter ConvertedStat;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ListBox RosterSelectListBox;
        
        internal System.Windows.Controls.Grid RushingContentPanel;
        
        internal System.Windows.Controls.ListBox OffenseRosterSelectListBox;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp1;component/Views/RosterPivot.xaml", System.UriKind.Relative));
            this.ShowOffense = ((PhoneApp1.Model.OffenseVisibility)(this.FindName("ShowOffense")));
            this.DisableBenchColor = ((PhoneApp1.Model.BenchColor)(this.FindName("DisableBenchColor")));
            this.ConvertedStat = ((PhoneApp1.Model.StatConverter)(this.FindName("ConvertedStat")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.RosterSelectListBox = ((System.Windows.Controls.ListBox)(this.FindName("RosterSelectListBox")));
            this.RushingContentPanel = ((System.Windows.Controls.Grid)(this.FindName("RushingContentPanel")));
            this.OffenseRosterSelectListBox = ((System.Windows.Controls.ListBox)(this.FindName("OffenseRosterSelectListBox")));
        }
    }
}

