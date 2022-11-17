Imports System
Imports DevExpress.Xpo
Imports System.Collections.Generic

Namespace Northwind

    <NonPersistent>
    Public Class Base
        Inherits XPLiteObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private Sub UpdateAudit(ByVal act As Action)
            Dim audit As Audit = New Audit(Session)
            audit.Action = act
            audit.Date = Date.Now
            audit.AuditedRecord = String.Format("{0}({1})", ClassInfo.FullName, Session.GetKeyValue(Me))
            audit.User = Environment.UserName
            For Each change As Change In changes
                Dim modInfo As ModificationInfo = New ModificationInfo(Session)
                modInfo.Audit = audit
                modInfo.PropertyName = change.PropertyName
                modInfo.OldValue = change.PrevValue
                modInfo.NewValue = change.Value
                modInfo.Save()
            Next

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
            Dim change As Change = New Change()
            change.PropertyName = ClassInfo.KeyProperty.Name
            change.PrevValue = Session.GetKeyValue(Me).ToString()
            change.Value = "<DELETED>"
            changes.Add(change)
            UpdateAudit(Action.Delete)
        End Sub

        Private changes As List(Of Change) = New List(Of Change)()

        Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
            MyBase.OnChanged(propertyName, oldValue, newValue)
            Dim change As Change = New Change()
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

    <Persistent("Category")>
    Public Class Categories
        Inherits Base

        Private fCategoryID As Integer

        <Key(True)>
        <Persistent("Id")>
        Public Property CategoryID As Integer
            Get
                Return fCategoryID
            End Get

            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CategoryID", fCategoryID, value)
            End Set
        End Property

        Private fCategoryName As String

        <Size(15)>
        Public Property CategoryName As String
            Get
                Return fCategoryName
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("CategoryName", fCategoryName, value)
            End Set
        End Property

        Private fDescription As String

        <Size(1073741823)>
        Public Property Description As String
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

        Public Property User As String
            Get
                Return fUser
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("User", fUser, value)
            End Set
        End Property

        Private fDate As Date

        Public Property [Date] As Date
            Get
                Return fDate
            End Get

            Set(ByVal value As Date)
                SetPropertyValue("Date", fDate, value)
            End Set
        End Property

        Private fAction As Action

        Public Property Action As Action
            Get
                Return fAction
            End Get

            Set(ByVal value As Action)
                SetPropertyValue("Action", fAction, value)
            End Set
        End Property

        Private fAuditedRecord As String

        Public Property AuditedRecord As String
            Get
                Return fAuditedRecord
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("AuditedRecord", fAuditedRecord, value)
            End Set
        End Property

        <Association("Audit-ModificationInfo")>
        Public ReadOnly Property Modifications As XPCollection(Of ModificationInfo)
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

        Public Property PropertyName As String
            Get
                Return fPropertyName
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("PropertyName", fPropertyName, value)
            End Set
        End Property

        Private fOldValue As String

        Public Property OldValue As String
            Get
                Return fOldValue
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("OldValue", fOldValue, value)
            End Set
        End Property

        Private fNewValue As String

        Public Property NewValue As String
            Get
                Return fNewValue
            End Get

            Set(ByVal value As String)
                SetPropertyValue(Of String)("NewValue", fNewValue, value)
            End Set
        End Property

        Private fAudit As Audit

        <Association("Audit-ModificationInfo")>
        Public Property Audit As Audit
            Get
                Return fAudit
            End Get

            Set(ByVal value As Audit)
                SetPropertyValue("Audit", fAudit, value)
            End Set
        End Property
    End Class

    Public Enum Action
        Insert
        Update
        Delete
    End Enum
End Namespace
