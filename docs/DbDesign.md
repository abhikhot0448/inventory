# Purches Database Schema

## Tables in this schema

### Vendors Table
The Vendor Table serves as a repository for managing vendor information, allowing businesses to easily track and organize vendor details, maintain effective communication, and make informed procurement decisions.

|Column name| Description|
| ----------- | ----------- |
|Id|The unique id to identify the Vendor.|
|ClientId|The unique id to identify the Client.|
|Name|The name of the vendor.|
|ContactPerson|The name of the person responsible for communication with the vendor.|
|Email|	The email of the vendor. It can be used for login and registration purposes.|
|PhoneNumber|	The phone number of the vendor.|
|Address	|The address of the vendor.|
|CreatedBy | The vendor or account that created the vendor entry.|
|CreatedDate	| The date and time when the vendor entry was created.|
|LastModifiedBy	| The vendor or account that last modified the vendor entry.|
|LastModifiedDate| The date and time when the vendor entry was last modified.|
|IsActive| A flag indicating whether the vendor is active or inactive.|


  ### BillHeaders Table

The BillHeaders Table serves as a repository for managing BillHeaders information, allowing businesses to easily track and organize BillHeader details.

| Column Name       | Description                                               |
| ----------------  | --------------------------------------------------------- |
| Id                | The unique id to identify the BillHeader.                  |
| ClientId          | The id to identify the Client.                     |
| DueDate           | The Nullable Due Date of bill header                      |
| Amount            | The transaction Amount which is required field.           |
| Currency          | The transaction Amount Currency which is required field   |
| PaymentTerm       | The "PaymentTerm" column provides a way to store and track the specific payment terms associated with each bill or invoice, allowing businesses to manage their cash flow, plan for payments, and ensure timely payments to suppliers |
| BillStatusId      | The id to identify the Bill Status                        |
| SupplierId        | The id to identify the Supplier                           |
| CoaId             | The id to identify the CoaId                              |
| BillPaymentId     | The id to identify the CoaId                              |
| CreatedBy         | The user or account that created the BillHeader entry.       |
| CreatedDate       | The date and time when the BillHeader entry was created.     |
| LastModifiedBy    | The user or account that last modified the BillHeader entry. |
| LastModifiedDate  | The date and time when the BillHeader entry was last modified. |
| IsActive          | A flag indicating whether the BillHeader is active or inactive. |



  ### BillDetails Table

The BillDetails Table serves as a repository for managing BillDetails information, allowing businesses to easily track and organize Bill details.

| Column Name       | Description                                               |
| ----------------  | --------------------------------------------------------- |
| Id                | The unique id to identify the BillDetail.                  |
| ClientId          | The id to identify the Client.                     |
| BillHeaderId      | The id to identify the BillHeader.                      |
| Amount            | The transaction Amount .                                  |
| Currency          | The transaction Amount Currency                            |
| CoaId             | The id to identify the CoaId                              |
| CreatedBy         | The user or account that created the BillHeader entry.       |
| CreatedDate       | The date and time when the BillHeader entry was created.     |
| LastModifiedBy    | The user or account that last modified the BillHeader entry. |
| LastModifiedDate  | The date and time when the BillHeader entry was last modified. |
| IsActive          | A flag indicating whether the BillHeader is active or inactive. |

# Cash Database Schema

## Tables in this schema  



# Sales Database Schema

## Tables in this schema

### Customers Table

The Customers Table serves as a repository for managing Customers information, allowing businesses to easily track and organize Customers details, maintain effective communication, and make informed procurement decisions.

| Column Name       | Description                                               |
| ----------------  | --------------------------------------------------------- |
| Id                | The unique id to identify the Customer                  |
| ClientId          | The unique id to identify the Client.                     |
| Name              | The name of the Customer.                                 |
| ContactPerson     | The name of the person responsible for communication with the Customer. |
| Email             | The email of the Customer. It can be used for login and registration purposes. |
| PhoneNumber       | The phone number of the Customer.                          |
| Address           | The address of the Customer.                               |
| CreatedBy         | The user or account that created the Customer entry.       |
| CreatedDate       | The date and time when the Customer entry was created.     |
| LastModifiedBy    | The user or account that last modified the Customer entry. |
| LastModifiedDate  | The date and time when the Customer entry was last modified. |
| IsActive          | A flag indicating whether the Customer is active or inactive. |





# Referntials Database Schema

## Tables in this schema


### Clients Table

The Clients Table serves as a repository for managing Clients information, allowing businesses to easily track and organize Clients details, maintain effective communication, and make informed procurement decisions.

| Column Name       | Description                                               |
| ----------------  | --------------------------------------------------------- |
| Id                | The unique id to identify the Client.                  |
| Name              | The name of the Client.                                 |
| ContactPerson     | The name of the person responsible for communication with the Client. |
| Email             | The email of the Client. It can be used for login and registration purposes. |
| PhoneNumber       | The phone number of the Client.                          |
| Address           | The address of the Client.                               |
| CreatedBy         | The user or account that created the Client entry.       |
| CreatedDate       | The date and time when the Client entry was created.     |
| LastModifiedBy    | The user or account that last modified the Client entry. |
| LastModifiedDate  | The date and time when the Client entry was last modified. |
| IsActive          | A flag indicating whether the Client is active or inactive. |


### Users Table

The Users Table serves as a repository for managing Users information, allowing businesses to easily track and organize Users details, maintain effective communication, and make informed procurement decisions.

| Column Name       | Description                                               |
| ----------------  | --------------------------------------------------------- |
| Id                | The unique id to identify the User.                  |
| ClientId          | The unique id to identify the Client.   
| FirstName         | The first name of the User.                                   |
| LastName          | The last name of the User.                                 |
| ContactPerson     | The name of the person responsible for communication with the User. |
| Email             | The email of the Users. It can be used for login and registration purposes. |
| PhoneNumber       | The phone number of the User.                          |
| Address           | The address of the User.                               |
| CreatedBy         | The user or account that created the CoA entry.       |
| CreatedDate       | The date and time when the User entry was created.     |
| LastModifiedBy    | The user or account that last modified the User entry. |
| LastModifiedDate  | The date and time when the User entry was last modified. |
| IsActive          | A flag indicating whether the User is active or inactive. |








