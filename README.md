# Api_Task


<h1>Tables</h> ::
tblItem [intItemId(pk), strItemName, numStockQuantity, isActive]
 
tblPartnerType [intPartnerTypeId(pk), strPartnerTypeName, isActive]
tblPartner [intPartnerId(pk), strPartnerName, intPartnerTypeId,isActive]
 
tblSales [intSalesId(pk), intCustomerId, dteSalesDate, isActive]
tblSalesDetails [intDetailsId(pk),intSalesId, intItemId, numItemQuantity, numUnitPrice, isActive]
 
tblPurchase [intPurchaseId(pk), intSupplierId, dtePurchaseDate, isActive]
tblPurchaseDetails [intDetailsId(pk), intPurchaseId, intItemId,  numItemQuantity, numUnitPrice, isActive]

<h1>API</h1>
1# Create partner type [Customer, Supplier]
2# Create some customer and supplier [Single]
3# Create Some items [List of item, don’t allow duplicates]
4# Edit some items [List of item, don’t allow duplicates]

5# Purchase Some item from a supplier
6# Sale some item to a customer [ Check stock while selling items]

7# Find item wise Daily Purchase report [Define your own fields for report]
8# Find item wise Monthly Sales report [Define your own fields for report]
09# Find item wise Daily Purchase vs Sales Report
10# Find Report with given column
(Month name, year, total purchase amount, total sales amount, profit/loss status)




