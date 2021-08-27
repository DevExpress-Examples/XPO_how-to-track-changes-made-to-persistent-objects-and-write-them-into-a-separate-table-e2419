<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128586249/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2419)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Q149895/Form1.cs) (VB: [Form1.vb](./VB/Q149895/Form1.vb))
* **[Northwind.cs](./CS/Q149895/Northwind.cs) (VB: [Northwind.vb](./VB/Q149895/Northwind.vb))**
* [Program.cs](./CS/Q149895/Program.cs) (VB: [Program.vb](./VB/Q149895/Program.vb))
<!-- default file list end -->
# How to track changes made to persistent objects, and write them into a separate table


<p>The OnSaving and OnDeleting method of the persistent objects can be overridden to log create/update/delete actions into a separate table. This example demonstrates the basic implementation of this feature.</p><p><strong>Note:</strong> eXpressApp Framework have built-in module for Audit purposes. This example demonstrates how to use this module in non XAF application: <a href="https://www.devexpress.com/Support/Center/p/E2274">How to use XAF Audit Trail module outside XAF</a>.</p>

<br/>


