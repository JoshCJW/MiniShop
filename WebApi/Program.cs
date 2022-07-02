global using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Welcome to My MiniShop API");



#region Register/Login


#endregion

#region Customers

async Task<List<Customer>> GetAllCust(DataContext context) => await context.Customers.ToListAsync();


//Get all customers
app.MapGet("/Customers", async (DataContext context) => await context.Customers.ToListAsync());

//Get Single Customer, If CustID not founf will promt error
app.MapGet("/Customer/{id}", async (DataContext context, int id) =>
    await context.Customers.FindAsync(id) is Customer cust ? Results.Ok(cust) : Results.NotFound("Customer not found"));

// Creating of Customer
app.MapPost("/Customer", async (DataContext context, Customer cust) =>

{
    context.Customers.Add(cust);
    await context.SaveChangesAsync();
    // Return all customers after save changes
    return Results.Ok(await GetAllCust(context));
});

// Update of Customer
app.MapPut("/Customer/{id}", async (DataContext context, Customer cust, int id) =>
{
    var dbCust = await context.Customers.FindAsync(id);
    if (dbCust == null) return Results.NotFound("No Customer Found");

    dbCust.Name = cust.Name;
    dbCust.ContactNo = cust.ContactNo;
    await context.SaveChangesAsync();
    // Return all customers after save changes
    return Results.Ok(await GetAllCust(context));

});

// Delete of Customer
app.MapDelete("/Customer/{id}", async (DataContext context, int id) =>
{
    var dbCust = await context.Customers.FindAsync(id);
    if (dbCust == null) return Results.NotFound("Error. Customer not Found");

    context.Customers.Remove(dbCust);
    await context.SaveChangesAsync();
    // Return all customers after save changes
    return Results.Ok(await GetAllCust(context));
});


#endregion

#region Products
async Task<List<Product>> GetAllProd(DataContext context) => await context.Products.ToListAsync();

// Getting all Products
app.MapGet("/Products", async (DataContext context) => await context.Products.ToListAsync());

// Getting a Single Product, If product id is not found will promot error
app.MapGet("/Product/{id}", async (DataContext context, int id) =>
    await context.Products.FindAsync(id) is Product prod ? Results.Ok(prod) : Results.NotFound("Product not found"));

// Creating of Product
app.MapPost("/Product", async (DataContext context, Product prod) =>

{
    context.Products.Add(prod);
    await context.SaveChangesAsync();
    // Return all products after save changes
    return Results.Ok(await GetAllProd(context));
});

// Update of Product
app.MapPut("/Product/{id}", async (DataContext context, Product prod, int id) =>
{
    var dbProd = await context.Products.FindAsync(id);
    if (dbProd == null) return Results.NotFound("No Product Found");

        dbProd.prodImg = prod.prodImg;
        dbProd.ProdName = prod.ProdName;
        dbProd.ProductDesc = prod.ProductDesc;
        dbProd.Quantity = prod.Quantity;
        dbProd.Price = prod.Price;
        await context.SaveChangesAsync();
        // Return all products after save changes
        return Results.Ok(await GetAllProd(context));

});

// Delete of Product
app.MapDelete("/Product/{id}", async (DataContext context, int id) =>
{
    var dbProd = await context.Products.FindAsync(id);
    if (dbProd == null) return Results.NotFound("Error. Product not Found");

    context.Products.Remove(dbProd);
    await context.SaveChangesAsync();
    // Return all product after save changes
    return Results.Ok(await GetAllProd(context));
});

#endregion

#region Orders
async Task<List<Order>> GetAllOrd(DataContext context) => await context.Orders.ToListAsync();
// Getting all orders
app.MapGet("/Orders", async (DataContext context) => await context.Orders.ToListAsync());

// Getting a Single order, If order id is not found will promot error
app.MapGet("/Order/{id}", async (DataContext context, int id) =>
    await context.Orders.FindAsync(id) is Order ord ? Results.Ok(ord) : Results.NotFound("Order not found"));

// Creating of Order
app.MapPost("/order", async (DataContext context, Order ord) =>

{
    context.Orders.Add(ord);
    await context.SaveChangesAsync();
    // Return all orders after save changes
    return Results.Ok(await GetAllOrd(context));
});
// Update of Order
app.MapPut("/Order/{id}", async (DataContext context, Order ord, int id) =>
{
    var dbOrd = await context.Orders.FindAsync(id);
    if (dbOrd == null) return Results.NotFound("No Product Found");

    dbOrd.OrderDetailID = ord.OrderDetailID;
    dbOrd.CustID = ord.CustID;
    dbOrd.Amt = ord.Amt;


    await context.SaveChangesAsync();
    // Return all order after save changes
    return Results.Ok(await GetAllOrd(context));

});
// Delete of Order
app.MapDelete("/Order/{id}", async (DataContext context, int id) =>
{
    var dbOrd = await context.Orders.FindAsync(id);
    if (dbOrd == null) return Results.NotFound("Error. Order not Found");

    context.Orders.Remove(dbOrd);
    await context.SaveChangesAsync();
    // Return all product after save changes
    return Results.Ok(await GetAllOrd(context));
});
#endregion

#region OrderDetails
async Task<List<OrderDetails>> GetAllOrdDetails(DataContext context) => await context.OrderDetails.ToListAsync();

// Getting all orderdeatils
app.MapGet("/OrdersDetails", async (DataContext context) => await context.OrderDetails.ToListAsync());

// Getting a Single orderdetail, If order detail id is not found will promot error
app.MapGet("/OrdersDetails/{id}", async (DataContext context, int id) =>
    await context.OrderDetails.FindAsync(id) is OrderDetails ordet ? Results.Ok(ordet) : Results.NotFound("Order detail not found"));

// Creating of OrderDetails
app.MapPost("/OrdersDetail", async (DataContext context, OrderDetails ordet) =>

{
    context.OrderDetails.Add(ordet);
    await context.SaveChangesAsync();
    // Return all orders after save changes
    return Results.Ok(await GetAllOrdDetails(context));
});


// Update of Order Details
app.MapPut("/OrderDetail/{id}", async (DataContext context, OrderDetails ordet, int id) =>
{
    var dbOrdet = await context.OrderDetails.FindAsync(id);
    if (dbOrdet == null) return Results.NotFound("No Product Found");

    dbOrdet.ProdId = ordet.ProdId;
    dbOrdet.Qty = ordet.Qty;

    await context.SaveChangesAsync();
    // Return all order after save changes
    return Results.Ok(await GetAllOrdDetails(context));

});

// Delete of OrderDetail
app.MapDelete("/OrderDetail/{id}", async (DataContext context, int id) =>
{
    var dbOrdet = await context.OrderDetails.FindAsync(id);
    if (dbOrdet == null) return Results.NotFound("Error. Order Details not Found");

    context.OrderDetails.Remove(dbOrdet);
    await context.SaveChangesAsync();
    // Return all product after save changes
    return Results.Ok(await GetAllOrdDetails(context));
});

#endregion

#region TransactionDetails
async Task<List<TransactionDetails>> GetAllTransactionDetails(DataContext context) => await context.TransactionDetails.ToListAsync();

// Getting a Single transaction ID, If Transaction id is not found will promot error
app.MapGet("/TransactionDetail/{id}", async (DataContext context, int id) =>
    await context.TransactionDetails.FindAsync(id) is TransactionDetails ordet ? Results.Ok(ordet) : Results.NotFound("Transaction detail not found"));


// Creating of Transaction Details
app.MapPost("/TransactionDetail", async (DataContext context, TransactionDetails TransDet) =>

{
    context.TransactionDetails.Add(TransDet);
    await context.SaveChangesAsync();
    return Results.Ok("Transaction Added");
});

// Update of Transactions Details
app.MapPut("/TransactionDetail/{id}", async (DataContext context, TransactionDetails TransDet, int id) =>
{
    var dbTransDet = await context.TransactionDetails.FindAsync(id);
    if (dbTransDet == null) return Results.NotFound("No Transaction Detail Found");

    dbTransDet.OrderID = TransDet.OrderID;
    dbTransDet.PaymentMethod = TransDet.PaymentMethod;
    dbTransDet.IsPaid = TransDet.IsPaid;
    dbTransDet.TransactionDateTime = TransDet.TransactionDateTime;

    await context.SaveChangesAsync();
    // Return all order after save changes
    return Results.Ok("Updated Completed");

});


// Delete of TransactionDetail
app.MapDelete("/TransactionDetail/{id}", async (DataContext context, int id) =>
{
    var dbTransDet = await context.TransactionDetails.FindAsync(id);
    if (dbTransDet == null) return Results.NotFound("Error. Transaction Details not Found");

    context.TransactionDetails.Remove(dbTransDet);
    await context.SaveChangesAsync();
    return Results.Ok("Deletion Completed");
});


#endregion

#region Codetable
async Task<List<CodeTable>> GetAllCodeTable(DataContext context) => await context.CodeTables.ToListAsync();


// Getting a Single CodeTable ID, If CodeTable id is not found will promot error
app.MapGet("/CodeTable/{id}", async (DataContext context, int id) =>
    await context.CodeTables.FindAsync(id) is CodeTable Ctdet ? Results.Ok(Ctdet) : Results.NotFound("Code Table Details not found"));


// Creating of Code Table Details
app.MapPost("/CodeTable", async (DataContext context, CodeTable CtDet) =>

{
    context.CodeTables.Add(CtDet);
    await context.SaveChangesAsync();
    return Results.Ok("CodeTable Added");
});

// Update of Code Table Details
app.MapPut("/CodeTable/{id}", async (DataContext context, CodeTable CtDet, int id) =>
{
    var dbCtdet = await context.CodeTables.FindAsync(id);
    if (dbCtdet == null) return Results.NotFound("No Code Table Detail Found");

    dbCtdet.desc = CtDet.desc;
    dbCtdet.longdesc = CtDet.longdesc;

    await context.SaveChangesAsync();

    return Results.Ok("Updated Completed");

});


// Delete of Code Table Detail
app.MapDelete("/CodeTable/{id}", async (DataContext context, int id) =>
{
    var dbCtdet = await context.CodeTables.FindAsync(id);
    if (dbCtdet == null) return Results.NotFound("Error. Code Table Details not Found");

    context.CodeTables.Remove(dbCtdet);
    await context.SaveChangesAsync();
    // Return all product after save changes
    return Results.Ok("Deletion Completed");
});



#endregion

#region CodetableApp

async Task<List<CodeTableApp>> GetAllCodeTableApp(DataContext context) => await context.CodeTableApps.ToListAsync();


// Getting a Single CodeTableApp ID, If CodeTable id is not found will promot error
app.MapGet("/CodeTableApp/{id}", async (DataContext context, int id) =>
    await context.CodeTableApps.FindAsync(id) is CodeTableApp CtAppdet ? Results.Ok(CtAppdet) : Results.NotFound("Code Table App Details not found"));


// Creating of CodeTable APP Details
app.MapPost("/CodeTableApp", async (DataContext context, CodeTableApp CtAppdet) =>

{
    context.CodeTableApps.Add(CtAppdet);
    await context.SaveChangesAsync();
    return Results.Ok("CodeTableApp Added");
});

// Update of Code Table App Details
app.MapPut("/CodeTableApp/{id}", async (DataContext context, CodeTableApp CtAppdet, int id) =>
{
    var dbCtAppdet = await context.CodeTableApps.FindAsync(id);
    if (dbCtAppdet == null) return Results.NotFound("No Code Table App Detail Found");

    dbCtAppdet.desc = CtAppdet.desc;
    dbCtAppdet.longdesc = CtAppdet.longdesc;

    await context.SaveChangesAsync();

    return Results.Ok("Updated Completed");

});


// Delete of Code Table App Details
app.MapDelete("/CodeTableApp/{id}", async (DataContext context, int id) =>
{
    var dbCtAppdet = await context.CodeTableApps.FindAsync(id);
    if (dbCtAppdet == null) return Results.NotFound("Error. Code Table App Details not Found");

    context.CodeTableApps.Remove(dbCtAppdet);
    await context.SaveChangesAsync();
    return Results.Ok("Deletion Completed");
});




#endregion

app.Run();
