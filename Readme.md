<!-- default file list -->
*Files to look at*:

* [Northwind.cs](./CS/Q149895/Northwind.cs) (VB: [Northwind.vb](./VB/Q149895/Northwind.vb))
<!-- default file list end -->
# How to track changes made to persistent objects, and write them into a separate table


<p>The OnSaving and OnDeleting method of the persistent objects can be overridden to log create/update/delete actions into a separate table. This example demonstrates the basic implementation of this feature.</p><p><strong>Note:</strong> eXpressApp Framework have built-in module for Audit purposes. This example demonstrates how to use this module in non XAF application: <a href="https://www.devexpress.com/Support/Center/p/E2274">How to use XAF Audit Trail module outside XAF</a>.</p>

<br/>


