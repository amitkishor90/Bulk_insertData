# Excel to SQL Server Bulk Insert using SqlBulkCopy use Ado.net

## Overview

This project provides a high-performance solution for importing large datasets (e.g., 100,000+ records) from an **Excel** file into a **SQL Server** database. It uses the **`SqlBulkCopy`** class for fast and efficient bulk data insertion without the need for loops.

## Features

- **Bulk Data Import**: Efficiently inserts large datasets from Excel to SQL Server.
- **No Loops**: Utilizes `SqlBulkCopy` to insert data in a single operation, avoiding the need for looping through rows.
- **Optimized for Performance**: Handles large volumes of data quickly and reduces memory overhead.
- **Easy Integration**: Can be easily integrated into C# applications with minimal setup.

## Requirements

- **.NET Framework** or **.NET Core** (C#)
- **ExcelDataReader** library for reading Excel files.
- **SQL Server** with a connection string to an existing database.
- **Excel file** with the data to be imported.
- dotnet add package Microsoft.Data.SqlClient


## Installation

### 1. Clone this repository:

```bash
git clone https://github.com/your-username/excel-to-sql-server-bulk-insert.git 
