Namespace Q149895

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.xpCollection1 = New DevExpress.Xpo.XPCollection()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colCategoryID = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colCategoryName = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.session1 = New DevExpress.Xpo.Session()
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.xpCollection1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.session1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' gridControl1
            ' 
            Me.gridControl1.DataSource = Me.xpCollection1
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            AddHandler Me.gridControl1.EmbeddedNavigator.ButtonClick, New DevExpress.XtraEditors.NavigatorButtonClickEventHandler(AddressOf Me.OnGridControlEmbeddedNavigatorButtonClick)
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(644, 427)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.UseEmbeddedNavigator = True
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
            ' 
            ' xpCollection1
            ' 
            Me.xpCollection1.DisplayableProperties = "This;CategoryID;CategoryName;Description"
            Me.xpCollection1.ObjectType = GetType(Northwind.Categories)
            Me.xpCollection1.Session = Me.session1
            ' 
            ' gridView1
            ' 
            Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCategoryID, Me.colCategoryName, Me.colDescription})
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            ' 
            ' colCategoryID
            ' 
            Me.colCategoryID.Caption = "CategoryID"
            Me.colCategoryID.FieldName = "CategoryID"
            Me.colCategoryID.Name = "colCategoryID"
            Me.colCategoryID.Visible = True
            Me.colCategoryID.VisibleIndex = 0
            ' 
            ' colCategoryName
            ' 
            Me.colCategoryName.Caption = "CategoryName"
            Me.colCategoryName.FieldName = "CategoryName"
            Me.colCategoryName.Name = "colCategoryName"
            Me.colCategoryName.Visible = True
            Me.colCategoryName.VisibleIndex = 1
            ' 
            ' colDescription
            ' 
            Me.colDescription.Caption = "Description"
            Me.colDescription.FieldName = "Description"
            Me.colDescription.Name = "colDescription"
            Me.colDescription.Visible = True
            Me.colDescription.VisibleIndex = 2
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(644, 427)
            Me.Controls.Add(Me.gridControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.gridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.xpCollection1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.gridView1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.session1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private gridControl1 As DevExpress.XtraGrid.GridControl

        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView

        Private xpCollection1 As DevExpress.Xpo.XPCollection

        Private colCategoryID As DevExpress.XtraGrid.Columns.GridColumn

        Private colCategoryName As DevExpress.XtraGrid.Columns.GridColumn

        Private colDescription As DevExpress.XtraGrid.Columns.GridColumn

        Private session1 As DevExpress.Xpo.Session
    End Class
End Namespace
