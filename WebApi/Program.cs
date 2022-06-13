global using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Data;
using WebApi.Controllers;

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
    dbCust.EmailAddress = cust.EmailAddress;
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

    dbOrd.refNo = ord.refNo;
    dbOrd.CustID = ord.CustID;
    dbOrd.ProdId = ord.ProdId;
    dbOrd.Qty = ord.Qty;
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

#region Codetable

#endregion

app.Run();
