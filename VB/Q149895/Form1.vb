Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Namespace Q149895

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnGridControlEmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As NavigatorButtonClickEventArgs)
            If e.Button.ButtonType = NavigatorButtonType.Remove Then
                CType(CType(gridControl1.FocusedView, GridView).GetFocusedRow(), XPBaseObject).Delete()
                e.Handled = True
            End If
        End Sub
    End Class
End Namespace
