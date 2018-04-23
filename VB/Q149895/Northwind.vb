Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports System.Collections.Generic

Namespace Northwind
	<NonPersistent> _
	Public Class Base
		Inherits XPLiteObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private Sub UpdateAudit(ByVal act As Action)
			Dim audit As New Audit(Session)
			audit.Action = act
			audit.Date = DateTime.Now
			audit.AuditedRecord = String.Format("{0}({1})", ClassInfo.FullName, Session.GetKeyValue(Me))
			audit.User = Environment.UserName
			For Each change As Change In changes
				Dim modInfo As New ModificationInfo(Session)
				modInfo.Audit = audit
				modInfo.PropertyName = change.PropertyName
				modInfo.OldValue = change.PrevValue
				modInfo.NewValue = change.Value
				modInfo.Save()
			Next change
			audit.Save()
		End Sub

		Protected Overrides Sub OnSaving()
			MyBase.OnSaving()
			If Session.IsNewObject(Me) Then
				UpdateAudit(Action.Insert)
			Else
				UpdateAudit(Action.Update)
			End If
		End Sub

		Protected Overrides Sub OnDeleting()
			MyBase.OnDeleting()
			Dim change As New Change()
			change.PropertyName = Me.ClassInfo.KeyProperty.Name
			change.PrevValue = Me.Session.GetKeyValue(Me).ToString()
			change.Value = "<DELETED>"
			changes.Add(change)
			UpdateAudit(Action.Delete)
		End Sub
		Private changes As New List(Of Change)()

		Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
			MyBase.OnChanged(propertyName, oldValue, newValue)
			Dim change As New Change()
			change.PropertyName = propertyName
			change.PrevValue = If(oldValue Is Nothing, "<NULL>", oldValue.ToString())
			change.Value = If(newValue Is Nothing, "<NULL>", newValue.ToString())
			changes.Add(change)
		End Sub

		Private Structure Change
			Public PropertyName As String
			Public PrevValue As String
			Public Value As String
		End Structure
	End Class

	Public Class Categories
		Inherits Base
		Private fCategoryID As Integer
		<Key(True)> _
		Public Property CategoryID() As Integer
			Get
				Return fCategoryID
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue(Of Integer)("CategoryID", fCategoryID, value)
			End Set
		End Property
		Private fCategoryName As String
		<Size(15)> _
		Public Property CategoryName() As String
			Get
				Return fCategoryName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("CategoryName", fCategoryName, value)
			End Set
		End Property
		Private fDescription As String
		<Size(1073741823)> _
		Public Property Description() As String
			Get
				Return fDescription
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("Description", fDescription, value)
			End Set
		End Property
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Sub New()
			MyBase.New(Session.DefaultSession)
		End Sub
		Public Overrides Sub AfterConstruction()
			MyBase.AfterConstruction()
		End Sub
	End Class

	Public Class Audit
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fUser As String
		Public Property User() As String
			Get
				Return fUser
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("User", fUser, value)
			End Set
		End Property
		Private fDate As DateTime
		Public Property [Date]() As DateTime
			Get
				Return fDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("Date", fDate, value)
			End Set
		End Property
		Private fAction As Action
		Public Property Action() As Action
			Get
				Return fAction
			End Get
			Set(ByVal value As Action)
				SetPropertyValue(Of Action)("Action", fAction, value)
			End Set
		End Property

		Private fAuditedRecord As String
		Public Property AuditedRecord() As String
			Get
				Return fAuditedRecord
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("AuditedRecord", fAuditedRecord, value)
			End Set
		End Property

		<Association("Audit-ModificationInfo")> _
		Public ReadOnly Property Modifications() As XPCollection(Of ModificationInfo)
			Get
				Return GetCollection(Of ModificationInfo)("Modifications")
			End Get
		End Property
	End Class

	Public Class ModificationInfo
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Private fPropertyName As String
		Public Property PropertyName() As String
			Get
				Return fPropertyName
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("PropertyName", fPropertyName, value)
			End Set
		End Property

		Private fOldValue As String
		Public Property OldValue() As String
			Get
				Return fOldValue
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("OldValue", fOldValue, value)
			End Set
		End Property

		Private fNewValue As String
		Public Property NewValue() As String
			Get
				Return fNewValue
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("NewValue", fNewValue, value)
			End Set
		End Property

		Private fAudit As Audit
		<Association("Audit-ModificationInfo")> _
		Public Property Audit() As Audit
			Get
				Return fAudit
			End Get
			Set(ByVal value As Audit)
				SetPropertyValue(Of Audit)("Audit", fAudit, value)
			End Set
		End Property
	End Class

	Public Enum Action
		Insert
		Update
		Delete
	End Enum
End Namespace
