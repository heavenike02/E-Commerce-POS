#  Commerce POS
This code is for creating a point of sale system for a car dealership.Below is a description of how each form interacts withtin the system  

The MainForm class is responsible for managing the main form of the application, including the user interface and functionality of the sidebar menu. The StartBlankDesign method hides all sub panels when the application starts, while the HideSubPanel method is used to hide any visible sub panels. The ShowSubMenu method is used to show a specific sub panel when its corresponding button in the sidebar menu is clicked. The OpenChildFord method is used to open and display child forms within the main application. There are also various event handlers for the buttons in the sidebar menu, which are used to open specific forms or perform specific actions when clicked. Overall, this code provides the framework for navigating and interacting with the point of sale system within the car dealership.

Mainform for a form in a point of sale system for a car dealership that is used to manage and display information about brands. The BrandForm class includes a constructor that initializes the form and loads the data from the "tbBrand" table into the data grid view. The LoadBrand method is used to retrieve and display the data from the table in the data grid view. The AddButton event handler opens a new form called BrandModule when clicked, allowing the user to add a new brand. The DGVBrand_CellContentClick event handler handles the edit and delete actions for a brand when the corresponding cell is clicked in the data grid view. The code also includes a method for updating the "tbBrand" table when a brand is added or edited, and for deleting a brand from the table.

BrandForm, a form in a point of sale system for a car dealership that is used to manage and display information about brands. The BrandForm class includes a constructor that initializes the form and loads the data from the "tbBrand" table into the data grid view. The LoadBrand method is used to retrieve and display the data from the table in the data grid view. The AddButton event handler opens a new form called BrandModule when clicked, allowing the user to add a new brand. The DGVBrand_CellContentClick event handler handles the edit and delete actions for a brand when the corresponding cell is clicked in the data grid view. The code also includes a method for updating the "tbBrand" table when a brand is added or edited, and for deleting a brand from the table

BrandModule form is used to add and edit brands in the system. The form includes event handlers for the SaveButton, CancelButton, and UpdateButton, which allow the user to save a new brand, clear the form's input fields, and update an existing brand, respectively. The Clear method is used to clear the input fields and reset the form to its default state. The ExitPictureBox event handler closes the form when clicked. The code also includes a try-catch block to handle any exceptions that may occur while saving or updating a brand. 

The CancelOrderForm is used to cancel orders in the system. The form includes an event handler for the SaveButton, which allows the user to cancel an order. The form also includes an InventoryComboBox and ReasonTextBox, which are used to select the item to be cancelled and enter the reason for the cancellation. The ExitPictureBox event handler closes the form when clicked. The code also includes a try-catch block to handle any exceptions that may occur while cancelling an order. The ReloadSoldList method is used to refresh the list of sold items in the system.
 
CashierForm  allows the user to initiate a new transaction, search for a product, add a discount, settle payment, clear the cart, view daily sales, change password, and log out. The form also displays the current date, transaction number, and total price of the items in the cart. There is also a function to slide a panel to highlight the selected button. The form connects to a database to retrieve and store information about the transaction and the products being purchased
.
 CategoryForm allows users to view and manage categories, which can include different types of cars or services offered at the dealership. The form displays a list of categories in a data grid view and provides buttons for adding, editing, and deleting categories. It connects to a database using SqlConnection and SqlCommand objects and utilizes a DBConnect class to establish the connection. The form includes a method for loading categories from the database into the data grid view and event handlers for interacting with cells in the data grid view and clicking the add and edit buttons. When the add button is clicked, a new form called CategoryModule is opened, and when a cell in the data grid view is clicked, the CategoryModule form is opened with the corresponding category pre-filled in the form.

 CategoryModule is used for managing categories, such as categories for different types of cars or services offered at the dealership. The form has textbox for entering a category name, as well as buttons for saving, updating, and cancelling changes. There is also a picture box with an exit icon, which closes the form when clicked. The form is able to connect to a database using the SqlConnection and SqlCommand objects, and itis using a DBConnect class for connecting to the database. The form also has a method for clearing the textbox and buttons, and a method for loading categories.
 
ChangePasswordForm changes the password of a user in the system. The form includes textboxes for entering a current password, a new password, and a confirm password, as well as buttons for confirming the change and for exiting the form. The form is able to connect to a database to retrieve and update the password of a user. The form includes a method for retrieving the current password of a user from the database based on the user's username. When the confirm button is clicked, the form checks if the current password matches the entered password. If they match, the form then checks if the new password and confirm password match. If they match, the form prompts the user to confirm the password change and, if confirmed, updates the password in the database. This form enables users to easily and securely change their passwords within the Point of Sale system.

DailySales  form includes a combo box for selecting a cashier, date pickers for selecting a date range to view sales, and a data grid view for displaying the sales details. The form is able to connect to a database to retrieve and display information about the sales. The form includes a method for loading the names of the cashiers into the combo box and a method for loading the sales details into the data grid view based on the selected cashier and date range. The form also displays the total sales for the selected period. This form allows users to easily view and track the sales of the car dealership on a daily basis.

DiscountForm allows users to apply a discount to a particular item in the POS system. The class uses a SqlConnection and SqlCommand to connect to and manipulate a database. When the ConfirmButton is clicked, the class checks if the user confirms applying the discount. If the user confirms, the discount is applied to the item in the database using an UPDATE statement. The class also has an ExitButton that, when clicked, closes the form and a DIscountPercentTextBox which allows users to input the percentage of the discount to be applied. When the text in DIscountPercentTextBox is changed, the class calculates and displays the amount of the discount in the DiscountAmountTextBox.
 
The Login  form  allows users to log into the application. It has a text box for the user to enter their username, a text box for the user to enter their password, and a button to submit the login information. The form also has a picture box that, when clicked, will close the application if the user confirms the action. When the login button is clicked, the form will check the entered username and password against a database of user information. If a matching username and password are found, the form will check if the user's account is active. If the account is inactive, a warning message will be displayed. If the account is active, the form will check the user's role and either open the main form for the application or the cashier form. The form will also clear the username and password text boxes and hide itself.

Product Form is  used to manage and display information about products. The form has a data grid view that displays information about products including the brand, category, model, registration, quantity, price, fuel type, engine size, mileage, transmission, road tax, and description. The form also has a search bar that allows the user to search for a product by its registration, brand, model, category, or brand. There is a button to add a new product, and buttons within the data grid view to edit or delete existing products. The code includes a method to load products into the data grid view and event handlers for when the add or edit buttons are clicked.

ProductModule is used to add or update product information. The form has several fields to input information such as brand, category, model, and price, as well as buttons to save or update a product and a button to clear the form. When the form loads, it calls the LoadBrand and LoadCategory methods to populate the BrandComboBox and CategoryComboBox fields with data from the database. The SaveButton_Click method is called when the save button is clicked, and it inserts a new product into the database using the input from the form fields. The Clear method is used to reset the form fields after a product is saved or updated. The UpdateButton_Click method is called when the update button is clicked, and it updates an existing product in the database using the input from the form fields. The ExitPictureBox_Click method is called when the exit button is clicked and it closes the form.

ProductSearch form allows users to search for and select products to add to a cart. The LoadProduct method is used to populate a DataGridView control with the search results, filtered by the text in the SearchMetroTextBox control. When a user clicks the "Select" button for a product, the product is added to the cart by inserting a new record into the tbCarts table in the database with the relevant information such as the transaction number, price, sale date, cashier, and the product's registration number. The LoadCart method in the CashierForm class is then called to update the display of the cart.

ResetPasswordForm allows a user to reset their password. The form contains several input fields and buttons, including a text box for the user to enter their new password, a text box for the user to confirm their new password, and a "Confirm" button to submit the password change request. When the user clicks the "Confirm" button, the code checks if the new password and confirm password fields match. If they do not match, an error message is displayed. If they do match, the code prompts the user to confirm the password change and, if confirmed, updates the password in a database table for the user's account and displays a message indicating that the password has been successfully reset. The form also includes a "Cancel" button which closes the form when clicked.

SettlePayment  allows a cashier to accept a deposit payment from a customer and updates the database with the transaction information. It has buttons for the cashier to enter the amount of the deposit, and a button to confirm the payment and update the database. It also has a function to clear the deposit amount. When the confirm button is clicked, the code loops through each row in a data grid view of the current transaction and updates the quantity of the product to 0 to indicate that it has been sold, updates the status of the item in the cart to "Sold", and adds the deposit amount to the cart for each item. It then displays a message indicating that the deposit has been saved and refreshes the cart.

 Supplier From has a DataGridView control for displaying a list of suppliers and various buttons for adding, updating, and deleting supplier records. When the Add button is clicked, a new SupplierModule form is opened, allowing the user to enter and save a new supplier record. When the Edit or Delete button is clicked in a row of the DataGridView, the SupplierModule form is opened with the corresponding supplier record's information pre-populated and the Save button disabled. The user can then update or delete the supplier record by clicking the Update or Cancel button in the SupplierModule form. The form also has a method called LoadSupply, which retrieves all of the supplier records from the database and displays them in the DataGridView.

The SupplierModule form is a partial form for managing suppliers . It includes functions to save and update supplier details to a database, as well as a function to clear the form's input fields. The form also includes various text boxes and buttons for interacting with the supplier data. The form is initialized with a Supplier object, which is used to refresh the supplier list in the main form when changes are made

 UserAccount form  allows the user to create and manage user accounts in the system. It has a data grid view that displays the existing user accounts, and several text boxes, labels, and buttons to create a new user account, change the password of an existing account, and delete an existing account. It also has a combo box to select the role of the user (e.g. admin, cashier). When the user clicks the "Save" button, a new user account is created in the database with the specified username, password, role, and name. When the user clicks the "Change Password" button, the password of the currently logged in user is updated in the database. When the user clicks the "Delete" button, the selected user account is deleted from the database. The form also has a "Clear" button to clear the input fields for creating a new user account.
 
VoidForm   allows a user to void a transaction. When the user clicks the "Void" button, the code verifies that the username and password entered match those of a user in the system's database. If the username and password are valid, it calls a function called "SaveCancelOrder" and passes the username as an argument. The "SaveCancelOrder" function then inserts the details of the transaction being voided, such as the transaction number and price, into a table called "tbCancelled" in the database. If the user has selected "Yes" in the "InventoryComboBox" to return the product to inventory, the code increases the quantity of the product in the "tbProduct" table by 1. It also updates the status of the transaction in the "tbCarts" table to "void". Finally, it displays a message confirming that the transaction has been successfully voided and closes the form.





Currently a work in progress
