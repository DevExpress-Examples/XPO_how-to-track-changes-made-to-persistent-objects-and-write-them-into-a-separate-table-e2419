using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System.Collections.Generic;

namespace Northwind {
    [NonPersistent]
    public class Base :XPLiteObject {
        public Base(Session session) : base(session) { }

        private void UpdateAudit(Action act) {
            Audit audit = new Audit(Session);
            audit.Action = act;
            audit.Date = DateTime.Now;
            audit.Table = ClassInfo.TableName;
            audit.User = Environment.UserName;
            foreach (Change change in changes) {
                ModificationInfo modInfo = new ModificationInfo(Session);
                modInfo.Audit = audit;
                modInfo.ProeprtyName = change.PropertyName;
                modInfo.OldValue = change.PrevValue;
                modInfo.NewValue = change.Value;
                modInfo.Save();
            }
            audit.Save();
        }

        protected override void OnSaving() {
            base.OnSaving();
            if (Session.IsNewObject(this)) UpdateAudit(Action.Insert);
            else UpdateAudit(Action.Update);
        }

        protected override void OnDeleting() {
            base.OnDeleting();
            UpdateAudit(Action.Delete);
        }

        private List<Change> changes = new List<Change>();

        protected override void OnChanged(string propertyName, object oldValue, object newValue) {
            base.OnChanged(propertyName, oldValue, newValue);
            Change change = new Change();
            change.PropertyName = propertyName;
            change.PrevValue = oldValue == null ? "<NULL>" : oldValue.ToString();
            change.Value = newValue == null ? "<NULL>" : newValue.ToString();
            changes.Add(change);
        }

        private struct Change {
            public string PropertyName;
            public string PrevValue;
            public string Value;
        }
    }

    public class Categories : Base {
        int fCategoryID;
        [Key(true)]
        public int CategoryID {
            get { return fCategoryID; }
            set { SetPropertyValue<int>("CategoryID", ref fCategoryID, value); }
        }
        string fCategoryName;
        [Size(15)]
        public string CategoryName {
            get { return fCategoryName; }
            set { SetPropertyValue<string>("CategoryName", ref fCategoryName, value); }
        }
        string fDescription;
        [Size(1073741823)]
        public string Description {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }
        public Categories(Session session) : base(session) { }
        public Categories() : base(Session.DefaultSession) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

    public class Audit : XPObject {
        public Audit(Session session) : base(session) { }

        private string fUser;
        public string User {
            get { return fUser; }
            set { SetPropertyValue<string>("User", ref fUser, value); }
        }
        private DateTime fDate;
        public DateTime Date {
            get { return fDate; }
            set { SetPropertyValue<DateTime>("Date", ref fDate, value); }
        }
        private Action fAction;
        public Action Action {
            get { return fAction; }
            set { SetPropertyValue<Action>("Action", ref fAction, value); }
        }

        private string fTable;
        public string Table {
            get { return fTable; }
            set { SetPropertyValue<string>("Table", ref fTable, value); }
        }

        [Association("Audit-ModificationInfo")]
        public XPCollection<ModificationInfo> Modifications { get { return GetCollection<ModificationInfo>("Modifications"); } }
    }

    public class ModificationInfo :XPObject {
        public ModificationInfo(Session session) : base(session) { }

        private string fPropertyName;
        public string ProeprtyName {
            get { return fPropertyName; }
            set { SetPropertyValue<string>("PropertyName", ref fPropertyName, value); }
        }

        private string fOldValue;
        public string OldValue {
            get { return fOldValue; }
            set { SetPropertyValue<string>("OldValue", ref fOldValue, value); }
        }

        private string fNewValue;
        public string NewValue {
            get { return fNewValue; }
            set { SetPropertyValue<string>("NewValue", ref fNewValue, value); }
        }

        private Audit fAudit;
        [Association("Audit-ModificationInfo")]
        public Audit Audit {
            get { return fAudit; }
            set { SetPropertyValue<Audit>("Audit", ref fAudit, value); }
        }
    }

    public enum Action { Insert, Update, Delete }
}
