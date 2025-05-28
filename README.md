# BakeshopManagementSystem

<!DOCTYPE html>
<html>
<head>
    <title>Retail Inventory System</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        table {
            width: 80%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th, td {
            padding: 8px 12px;
            border: 1px solid #ccc;
        }
        th {
            background-color: #f4f4f4;
        }
        .success {
            color: green;
        }
    </style>
</head>
<body>

<h1>Retail Inventory System - Products Table</h1>

<?php
// Database configuration
$servername = "localhost";
$username = "root"; // change if needed
$password = "";     // change if needed
$dbname = "retail_inventory"; // your database name

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("<p style='color:red;'>Connection failed: " . $conn->connect_error . "</p>");
}
echo "<p class='success'>Connected successfully to the database!</p>";

// Query to display products
$sql = "SELECT product_id, product_name, category_id, supplier_id, unit_price FROM Products";
$result = $conn->query($sql);

// Display data in table
if ($result->num_rows > 0) {
    echo "<table>";
    echo "<tr><th>Product ID</th><th>Name</th><th>Category ID</th><th>Supplier ID</th><th>Unit Price</th></tr>";
    while($row = $result->fetch_assoc()) {
        echo "<tr>
            <td>" . $row["product_id"] . "</td>
            <td>" . $row["product_name"] . "</td>
            <td>" . $row["category_id"] . "</td>
            <td>" . $row["supplier_id"] . "</td>
            <td>$" . number_format($row["unit_price"], 2) . "</td>
        </tr>";
    }
    echo "</table>";
} else {
    echo "<p>No products found.</p>";
}

// Close connection
$conn->close();
?>

</body>
</html>


-- Insert 4 records into different tables

-- Insert into Categories
INSERT INTO Categories (category_id, category_name, description, created_at, updated_at)
VALUES (1, 'Electronics', 'Electronic gadgets and devices', NOW(), NOW());

-- Insert into Suppliers
INSERT INTO Suppliers (supplier_id, supplier_name, contact_name, phone, email)
VALUES (1, 'GlobalTech Supplies', 'Anna Smith', '123-456-7890', 'anna@globaltech.com');

-- Insert into Products
INSERT INTO Products (product_id, product_name, category_id, supplier_id, unit_price)
VALUES (1, 'Smartphone X', 1, 1, 699.99);

-- Insert into Stores
INSERT INTO Stores (store_id, store_name, location, phone, manager_name)
VALUES (1, 'Main Branch', '123 Market St', '987-654-3210', 'John Doe');


-- Update 1 row per table

UPDATE Categories
SET description = 'Electronic devices and accessories'
WHERE category_id = 1;

UPDATE Suppliers
SET phone = '123-123-1234'
WHERE supplier_id = 1;

UPDATE Products
SET unit_price = 749.99
WHERE product_id = 1;

UPDATE Stores
SET manager_name = 'Jane Doe'
WHERE store_id = 1;

-- Insert into Employees to allow updating later
INSERT INTO Employees (employee_id, first_name, last_name, store_id, position)
VALUES (1, 'Emily', 'Clark', 1, 'Inventory Manager');

UPDATE Employees
SET position = 'Senior Inventory Manager'
WHERE employee_id = 1;


-- Rename a table
RENAME TABLE Stock_Movements TO Inventory_Movements;


-- Show table attributes/properties for 'Products'
-- In phpMyAdmin, you can use:
SHOW COLUMNS FROM Products;
-- Or if needed in SQL:
DESCRIBE Products;
