Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace Q149895
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			XpoDefault.ConnectionString = SQLiteConnectionProvider.GetConnectionString("nwind.sqlite")
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace