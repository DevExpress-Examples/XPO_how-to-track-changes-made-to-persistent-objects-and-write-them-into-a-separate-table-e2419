using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Q149895 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void OnGridControlEmbeddedNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            if (e.Button.ButtonType == NavigatorButtonType.Remove) {
                ((XPBaseObject)((GridView)gridControl1.FocusedView).GetFocusedRow()).Delete();
                e.Handled = true;
            }
        }
    }
}