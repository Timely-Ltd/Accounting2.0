# Accounting 2.0
Sample code for a hypothetical monolithic deployable. This repository is used as a basis for technical assessments and exercises.

## Overview
Accounting 2.0 is a large .NET Framework 4.6 application, with a React and Kotlin front end. The product is cloud based on Microsoft Azure and is deployed via GitHub/Jenkins. 


## Architecture
There are three web applications (AccountingWeb, MobileAPI and Invoicing). These are backed by a Microsoft SQL Server v19 database.

AccountingWeb runs on 3 large VM’s, and contains the following services in a monolith

- Authentication 
- Settings 
- Reports 
- Accounting 
- Billing 
- Partner 
- Customers 
- Bank Feeds 

<img width="2898" alt="Accounting 2 0 Architecture Diagram" src="https://github.com/user-attachments/assets/e053405a-bbe7-4dfe-8c40-4b8c3ec3e259">
