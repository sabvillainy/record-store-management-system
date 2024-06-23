# Inventory Management System For a Record Store
## Overview
This automation system has been developed to facilitate various inventory management processes of a record store. This system enables users to easily manage data related to the record store's employees, genres, artists, and products through a Windows Form application. The main objective of the project is to allow the addition, deletion, updating, and viewing of this data in an integrated manner with a database. This ensures that business processes in the record store are carried out more efficiently and without errors.

## Application Modules and Functionalities
### Login Panel
Allows users (admin or employee) to log into the system.

_Functionality:_
- Users select either admin or employee role before logging in.
- Admins logs in with username and password.
- Employees logs in with number and a password set by the admin.
- After validating the login details, users are granted access to appropriate modules.

![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/d621ee8d-87c6-4d4e-861c-57638d60c10f)


### Register Panel
Allows only admins to register. Employee registrations are done by admins through the Employees module. Not from here.

![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/dba0a924-ac5e-4c16-91db-612db04933ca)


### Admin Panel
- Add, edit and delete genres, artists exc. details for the products.
- Add, edit and delete products details.
- Add, edit and delete employee details.

![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/04a06d3e-b511-4bbb-ba5f-5c8883446415)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/1ef29007-2713-484d-923e-a7ab59b9c3d5)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/7c5d8193-9c1c-41a7-a94b-092eefc648db)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/afbe6ab4-fd9a-4ce0-aa49-9f5350a0b736)




### Sales Panel
The Sales Panel aims to process the products that customers want to buy at the checkout quickly and accurately. This module basically working as a cash register.

- Login into the provided he is authorised.
- View products + process sales.
- Add product and quantity being purchased.
- Purchased product's quantity is updating dynamically from products table after every purchase.
- Calculate the change to be given to the customer.

![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/d306ba6a-e093-4839-a1ef-7ef88ee58b54)

## How to Get It Working?
- Git Pull or download and unzip the file.
- Just incase, Visual Studio 22 was used.
- Create Microsoft SQL Server Database File (SqlClient) with the tables below.

**(I already added syntaxes of the SQL tables to the repository. It's not a SQL script, it's a .sql file that including syntaxes of the SQL tables. I recommend using Visual Studio Code to open that file. After opening the file, you can easily copy-paste syntaxes to your database's query.)**

![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/907cdcb5-2939-4a95-99b8-ca0840b5bfac)

![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/fbc6bac6-571f-49bb-ac38-fb0b4d96a72a)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/23240fda-173b-4e90-b8c2-1555ae38adc7)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/241a6b6b-aef3-4480-b881-4c8e079ee0f0)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/8a187613-df4c-45aa-b740-610cc3c606f2)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/dbfa3930-1402-47c2-b9af-6dac2e48b395)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/93e10e1c-49c2-4b03-b71a-aa6df7418c36)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/9cea8e38-9006-4b92-be50-5ac2e522385c)
![image](https://github.com/sabvillainy/record-store-management-system/assets/163596339/b94a4873-e27c-432e-a5de-937593afb50c)


- Connect your database with SqlConnection class.
- Run.

## Conclusion
This automation system represents a significant advancement in streamlining the operations of a music retail business. By integrating a comprehensive suite of modules that manage employees, music genres, artists, products, and sales, this system enhances efficiency and accuracy in daily operations. The user-friendly Windows Form application ensures that staff members can easily add, update, and manage data, while the seamless database integration guarantees that all information is current and correctly synchronized.

The Login and Register Panels provide secure access for admins and employees, ensuring that only authorized personnel can manage sensitive data. The specialized modules for employees, genres, artists, and products allow for detailed and organized data management, enabling the record store to maintain an up-to-date and accurate inventory. The Sales Panel further optimizes the checkout process, making it faster and more reliable, thus improving customer satisfaction and reducing the likelihood of errors.

Overall, the implementation of this system is not only enhances operational efficiency but also contributes to a more structured and error-free environment. This system ultimately supports the record store in achieving higher productivity and better service delivery, paving the way for sustained growth and customer loyalty.
