# Api_Task


<h1>Tables</h> ::
<p><h3>
<li>tblItem [intItemId(pk), strItemName, numStockQuantity, isActive]</li>
 
<li>tblPartnerType [intPartnerTypeId(pk), strPartnerTypeName, isActive]</li>
<li>tblPartner [intPartnerId(pk), strPartnerName, intPartnerTypeId,isActive]</li>
 
<li>tblSales [intSalesId(pk), intCustomerId, dteSalesDate, isActive]</li>
<li>tblSalesDetails [intDetailsId(pk),intSalesId, intItemId, numItemQuantity, numUnitPrice, isActive]/li>
 
<li>tblPurchase [intPurchaseId(pk), intSupplierId, dtePurchaseDate, isActive]</li>
<li>tblPurchaseDetails [intDetailsId(pk), intPurchaseId, intItemId,  numItemQuantity, numUnitPrice, isActive]<li>
</h3></p>
<h1>API</h1>
<ol>
<li> Create partner type [Customer, Supplier]</li>
<li>Create some customer and supplier [Single]</li>
<li> Create Some items [List of item, don’t allow duplicates]</li>
<li> Edit some items [List of item, don’t allow duplicates]</li>

<li> Purchase Some item from a supplier</li>
<li> Sale some item to a customer [ Check stock while selling items]</li>

<li> Find item wise Daily Purchase report [Define your own fields for report]</li>
<li> Find item wise Monthly Sales report [Define your own fields for report]</li>
<li> Find item wise Daily Purchase vs Sales Report</li>
<li> Find Report with given column</li>
(Month name, year, total purchase amount, total sales amount, profit/loss status)
</ol>



