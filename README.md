# User Profile Application

This project is an Angular application that allows users to input their profile information, including social skills and accounts, and submit it to a backend API. It features dynamic form fields for social skills and accounts, Angular Material components for UI elements, and error handling for form submissions.

## Features

- **User Input Form**: Allows users to input their first name, last name, social skills, and social media accounts.
- **Dynamic Form Fields**: Users can add multiple social skills and social media accounts dynamically.
- **Backend Integration**: Submits user profile data to a backend API.

## Frontend Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/jensuenk/InimcoDeveloperExercise.git
   cd InimcoDeveloperExerciseClient
   ```

2. **Install Dependencies**:
   ```bash
   npm install
   ```

3. **Run the Development Server**:
   ```bash
   ng serve
   ```
   Navigate to `http://localhost:4200/` in your web browser to view the application.

### Usage

1. **Fill out the User Profile Form**:
   - Enter your first name and last name.
   - Add social skills by clicking "Add Skill" and entering a skill.
   - Add social media accounts by clicking "Add Account," selecting a type from the dropdown, and entering the account name.

2. **Submit the Form**:
   - Click the "Submit" button to send your profile data to the backend API.
   - If successful, a confirmation message will be displayed. If there are errors, they will be shown in a notification at the bottom of the screen.

### Testing

- **Unit Tests**: The project includes unit tests for components and services using Jasmine and Karma. To run the tests, use:
  ```bash
  ng test
  ```

### Deployment

- **Build the Application**:
  ```bash
  ng build --prod
  ```
  The build artifacts will be stored in the `dist/` directory.

- **Deployment to Production**:
  Deploy the contents of the `dist/` directory to your web server.

## Backend Setup Instructions

1. **Clone the Backend Repository**:
   ```bash
   cd InimcoDeveloperExerciseApi
   ```

2. **Install Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the API Server**:
   ```bash
   dotnet run
   ```
   The API server will start running on `http://localhost:5079`.

4. **Verify API Endpoint**:
   Open a web browser and navigate to `http://localhost:5079/swagger` to view the Swagger UI documentation and verify that the API is running correctly.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please submit an issue or pull request.

## License

This project is licensed under the [MIT License](LICENSE).

