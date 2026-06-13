# Unit Converter API

A simple ASP.NET Core Web API that converts values between different units of measurement.

## Supported Categories and Units

### Length

category:length

| Unit      | Description               |
| --------- | ------------------------- |
| meter     | Base unit                 |
| kilometer | 1 kilometer = 1000 meters |
| feet      | Imperial length unit      |
| inch      | Imperial length unit      |

### Weight

category:weight

| Unit     | Description          |
| -------- | -------------------- |
| kilogram | Base unit            |
| gram     | Metric weight unit   |
| pound    | Imperial weight unit |

### Temperature

category:temperature

| Unit       | Description                  |
| ---------- | ---------------------------- |
| celsius    | Metric temperature scale     |
| fahrenheit | Imperial temperature scale   |
| kelvin     | Scientific temperature scale |

## Tech Stack

- ASP.NET Core 8
- Swagger / OpenAPI

## Running the Project

Prerequisites

    .NET 8 SDK installed

    Git (optional)

Verify the installation:

dotnet --version

Clone the Repository

git clone <repository-url>
cd UnitConverter

run:

```bash
dotnet restore
dotnet run
```

After the application starts, open Swagger using the URL displayed in the console:

```text
https://localhost:<port>/swagger
```

## API Endpoint

### Convert Units

```http
POST /api/conversion/convert
```

### Request

```json
{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "feet",
  "value": 10
}
```

### Response

```json
{
  "originalValue": 10,
  "fromUnit": "meter",
  "toUnit": "feet",
  "convertedValue": 32.8084
}
```

## Example Requests

### Length Conversion

```json
{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "feet",
  "value": 10
}
```

### Weight Conversion

```json
{
  "category": "weight",
  "fromUnit": "kilogram",
  "toUnit": "pound",
  "value": 5
}
```

### Temperature Conversion

```json
{
  "category": "temperature",
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "value": 25
}
```

## Error Handling

The API returns a 400 Bad Request response when an unsupported category or unit is provided.

Example:

```json
{
  "error": "Unsupported unit: lightyear"
}
```

## Project Structure

```text
Controllers/
Models/
Services/
Middleware/
```

- Controllers handle HTTP requests and responses.
- Services contain the conversion logic.
- Middleware provides centralized exception handling.
- Models represent request and response objects.

## Notes

For simplicity, units and conversion factors are hardcoded in the application. The current structure can be extended in the future to load units from a database or configuration source.

## Design Decisions

Solution Overview

The application is built as a simple ASP.NET Core Web API that converts values between different units of measurement. The API currently supports three conversion categories:

    length

    weight

    temperature

Conversion factors are stored in memory using dictionaries for simplicity and to keep the solution focused on the API design rather than data persistence.
Project Structure

The project follows a simple layered structure:

    Controllers handle HTTP requests and responses.

    Services contain the conversion logic.

    Middleware provides centralized exception handling.

    Models represent request data.

This separation keeps responsibilities clear and makes the code easier to maintain and extend.
Design Decisions and Trade-offs

    Conversion units and factors are hardcoded because persistence was not required for this exercise.

    A service layer was introduced to separate business logic from controllers.

    Global exception middleware is used to avoid repetitive try-catch blocks in controllers.

    Interfaces and additional abstraction layers were intentionally omitted to keep the solution straightforward and easy to understand.

    The current implementation can be extended in the future to support additional conversion categories or load conversion data from a database or configuration source.

Future Improvements

Possible enhancements include:

    Adding unit tests.

    Adding request validation.

    Supporting additional conversion categories.

    Storing conversion definitions in a database.

    Adding API versioning for backward compatibility.
