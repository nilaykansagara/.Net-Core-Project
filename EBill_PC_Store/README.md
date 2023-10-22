# EBill Generator - .NET Core MVC Project

## Overview

This is a .NET Core MVC project for generating electronic bills (eBills) targeted towards shop owners. It provides functionality for user registration, login, managing PC models, warranties, storage options, and generating bills.

## Features

- User Registration and Login
- Add/Edit/Delete PC Models
- Add/Edit/Delete Warranties
- Add/Edit/Delete Storage Options
- Generate Bills with Dropdowns for Model, Storage, and Warranty

## Prerequisites

- .NET Core SDK [Download Here](https://dotnet.microsoft.com/download)
- Visual Studio or Visual Studio Code (Optional)
- SQL Server for database management

## Setup

1. Clone the repository:

git clone https://github.com/your-username/eBill-Generator.git
   
  
2. Open the project in your preferred IDE (Visual Studio or Visual Studio Code).

3. Download the necessary packages:

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCoreIdentity.UI

4. Set up the database:

    a. Open SQL Server Management Studio (SSMS).
    b. Connect to your SQL Server instance.
    c. Add Dataconnection in Visual Studio
    d. Take connection string from properties and paste it into "appsetting.json" file.
    e. Run command : "add-migration init" on Package Manager Console and migrate databae to 
SSMS.
    f. Run command : "update-database" and update the database.

5. Run the application:


## Usage

1. Navigate to the registration page to create a new account.

2. Log in with your credentials.

3. Explore the various functionalities such as adding/editing/deleting PC models, warranties, and storage options.

4. To generate a bill, go to the bill generation page and use the dropdowns to select the desired model, storage, and warranty.

5. Edit or delete existing models, warranties, storage, and bills as needed.

## Contributing

Contributions to EBill Generator are welcome. You can contribute by forking the project, making changes, and creating pull requests. Please ensure your changes are in line with the project's goals and coding standards.

## License

This project is licensed under the [MIT License](LICENSE.md).

## Contact

If you have any questions or need assistance, feel free to contact us at kadiyamanan77@gmail.com, nilaykansagara@gmail.com.

---

We hope EBill Generator simplifies the management for generating bills and adding new models, storages, warranties.