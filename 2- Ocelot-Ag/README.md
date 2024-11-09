# API Gateway Example with Ocelot

This project demonstrates how to use **Ocelot** as an API Gateway to route requests to multiple backend services running on different ports. This example includes two backend APIs:

1. **WeatherForecast API** - Provides weather data.
2. **ProductAPI** - Provides product information.

## Project Structure

- **OcelotAG**: The API Gateway project using Ocelot to route requests to backend services.
- **WeatherForecast**: A simple Web API that returns weather data.
- **ProductAPI**: A simple Web API that returns product data.

## Setup and Configuration

### 1. Clone the Repository

### 2. Configure Ports for Backend APIs

Each backend API is set up to run on a different port to demonstrate Ocelot's routing capabilities.

- **WeatherForecast API** runs on port **5274**.
- **ProductAPI** runs on port **5275**.

These ports are configured in each project's `Properties/launchSettings.json`.

### 3. Ocelot Configuration

The routing for Ocelot is defined in `OcelotAG/ocelot.json`.

### 4. Run the Solution

- Start **WeatherForecast** and **ProductAPI** projects.
- Start the **OcelotAG** project.

### 5. Testing

Access the following endpoints through Ocelot (API Gateway) running on `http://localhost:2020`:

- **WeatherForecast API**:

  - `GET http://localhost:2020/api/weatherOC`

- **ProductAPI**:
  - `GET http://localhost:2020/api/productsOC`
  - `GET http://localhost:2020/api/productsOC/{id}`

### Project Dependencies

- **Ocelot**: Used for API Gateway functionality.
- **Swagger**: Enabled in both backend services to visualize API endpoints.

### Notes

- The Ocelot Gateway configuration file (`ocelot.json`) can be modified to include additional routes or services.
- Swagger is enabled for development environments to explore the backend APIs individually.
