# test-ui

## Overview

This repo contains a test automation framework built with c#,Specflow and Playwright.It is designed to test the login functionality of sample web app(found online to test dummy application) by verifying successful login and validating error messages for invalid login attempts.

## Design choices
Page Object Model (POM):
Encapsulates web page interaction logic in dedicated classes, improving code reusability and readability.
Behavior-Driven Development (BDD):
Uses SpecFlow to write human-readable test scenarios in Gherkin syntax.
Configuration Management:
Stores environment-specific settings (e.g., URLs, credentials) in appsettings.json, allowing seamless updates without code changes.
Scenario Hooks:
Implements setup and teardown logic to initialize and dispose of browser sessions, ensuring isolated and reliable test execution.
Asynchronous Programming:
Leverages async/await for non-blocking operations, enhancing performance and scalability.
Error Handling and Assertions:
Ensures robust test validation by asserting page states and error messages using Playwright's built-in assertion library.

### Required software to run locally
- [.NET 7.0 SDK]
- Playwright CLI
- Visual Studio
- Specflow

## Project setup
1.Clone the repo:
git clone https://github.com/sgolyala87/test-ui
## Project structure
- Config/: Contains configuration files (e.g., appsettings.json).
- Pages/: Page Object Models (POM) for interacting with web pages.
- Features/: Gherkin feature files for test scenarios.
- Steps/: Step definitions implementing test logic.
- Setup/: Playwright initialization, hooks, and configurations.

## Run Tests
- Build the solution in Visual Studio
- From View tab in Visual studio - Select 'View Test Explorer'
- Right click on TestProject.Features and Run 
